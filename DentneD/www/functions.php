<?php
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

//set here the ajax registered functions
$registered_functions = array('events');

//List all events
function events() {
  global $mssqlConnection, $patientEventShowDoctorName, $lang, $login;

  if(!$login->isLoggedIn) {
    echo '[]';
    return;
  }

  $isLoginDoctor = false;
  $isLoginPatient = false;
  if($login->userType == 'D')
    $isLoginDoctor = true;
  else if($login->userType == 'P')
    $isLoginPatient = true;
  else {
    echo '[]';
    return;
  }

  $events_array = array();
  $query = <<<'EOT'
SELECT
  a.appointments_id AS id,
  a.appointments_title AS title,
  a.appointments_from AS start,
  a.appointments_to AS [end],
  d.doctors_surname + ' ' + d.doctors_name AS doctor,
  p.patients_surname + ' ' + p.patients_name + ' (' + CONVERT(varchar(10), p.patients_id) + ')' AS patient,
  r.rooms_name AS room
FROM appointments a
  INNER JOIN doctors d ON a.doctors_id = d.doctors_id
  INNER JOIN patients p ON a.patients_id = p.patients_id
  INNER JOIN rooms r ON a.rooms_id = r.rooms_id
WHERE
EOT;
  if($isLoginDoctor) {
    $query .= " d.doctors_id = " . (int)$login->userId . " AND ";
  } else if($isLoginPatient) {
		$query .= " p.patients_id = " . (int)$login->userId . " AND ";
	}	
  $query .= " CAST(a.appointments_from AS date) >= CAST('". (isset($_GET['start']) ? date('Y-m-d', strtotime($_GET['start'])) : '1970-01-01') . "' AS date) AND CAST(a.appointments_from AS date) <= CAST('". (isset($_GET['end']) ? date('Y-m-d', strtotime($_GET['end'])) : '1970-01-01') . "' AS date)";
  $mssqlResult = mssql_query($query, $mssqlConnection);
  while($row = mssql_fetch_array($mssqlResult)) {
      $events_array[] = array(
      'id' => $row['id'],
      'title' => $row['title'],
      'description' =>
        (!empty($row['notes']) ? $row['notes'] . '<br/>' : '') .
        '<b>' . $lang['MODALEVENT_PERIOD'] . '</b>: ' . date("Y/m/d H:i", strtotime($row['start'])) . ' - ' . date("H:i", strtotime($row['end'])) . '<br/>' .
        ($isLoginDoctor ? '<b>'.$lang['MODALEVENT_ROOM'].'</b>: ' . $row['room'] . '<br/>' : '') .
        ($isLoginDoctor ? '<b>'.$lang['MODALEVENT_PATIENT'].'</b>: ' . $row['patient'] . '<br/>' : '') .
        ($isLoginPatient && $patientEventShowDoctorName ? '<b>'.$lang['MODALEVENT_DOCTOR'].'</b>: ' . $row['doctor'] . '<br/>' : ''),
      'start' => date("Y/m/d H:i:s", strtotime($row['start'])),
      'end' => date("Y/m/d H:i:s", strtotime($row['end'])),
      'allDay' => false
    );
  }
  
  echo json_encode($events_array);
}

//Login handler class
//reference: https://github.com/panique/php-login-advanced by Panique
class Login {
  public $userId = -1;
  public $isLoggedIn = false;
  public $userType = null;
  public $userName = null;
  public $messages = '';

  private $mssqlConnection = null;
  private $isPatientLoginEnabled = false;
  private $cookieHashSecret = '123456';
  private $cookieTime = 5184000;
  private $tokenPurgeTime = 60;
  private $lang_loginsuccess = 'You have been successfully logged in.';
  private $lang_loginerror = 'Can not log in.';
  private $lang_logoutsuccess = 'You have been successfully logged out.';

  //Login constructor
  public function __construct($mssqlConnection, $isPatientLoginEnabled, $cookieHashSecret, $cookieTime, $tokenPurgeTime, $lang_loginsuccess, $lang_loginerror, $lang_logoutsuccess) {
    
    //set variables
    $this->mssqlConnection = $mssqlConnection;
    $this->isPatientLoginEnabled = $isPatientLoginEnabled;
    $this->cookieHashSecret = $cookieHashSecret;
    $this->cookieTime = $cookieTime;
    $this->tokenPurgeTime = $tokenPurgeTime;
    $this->lang_loginsuccess = $lang_loginsuccess;
    $this->lang_loginerror = $lang_loginerror;
    $this->lang_logoutsuccess = $lang_logoutsuccess;

    //perform login/logout requests
    if (isset($_POST["logout"])) {
      $this->purgeTokens();
      $this->loginBySession();
      $this->logout();
    } elseif (!empty($_SESSION['userId']) && !empty($_SESSION['userName']) && !empty($_SESSION['userType']) && isset($_SESSION['isLoggedIn'])) {
      $this->loginBySession();
    } elseif (isset($_COOKIE['remindme'])) {
      $this->purgeTokens();
      $this->loginByCookie();
    } elseif (isset($_POST["login"])) {
      $this->purgeTokens();
      $this->loginByPost($_POST['username'], $_POST['password'], (!isset($_POST['remindme']) ? false : true));
    }

  }

  //Purge old tokens
  private function purgeTokens() {
    $query = "UPDATE doctors SET doctors_token = NULL, doctors_lastlogin = NULL WHERE doctors_lastlogin < DATEADD(day, " . -(int)$this->tokenPurgeTime. ", GETDATE())";
    mssql_query($query, $this->mssqlConnection);
    if($this->isPatientLoginEnabled) {
      $query = "UPDATE patients SET patients_token = NULL, patients_lastlogin = NULL WHERE patients_lastlogin < DATEADD(day, " . -(int)$this->tokenPurgeTime. ", GETDATE())";
      mssql_query($query, $this->mssqlConnection);  
    }
  }

  //MSSQL escape characters
  private function mssql_escape($data) {
    if(is_numeric($data))
      return $data;
    $unpacked = unpack('H*hex', $data);
    return '0x' . $unpacked['hex'];
  }

  //Perform login using Session
  private function loginBySession() {

    //unset credentials
    $this->userId = -1;
    $this->isLoggedIn = false;
    $this->userType = null;
    $this->userName = null;
    $this->messages = '';

    if(isset($_SESSION['isLoggedIn']) && $_SESSION['isLoggedIn'] == 1) {
      $this->userId = $_SESSION['userId'];
      $this->isLoggedIn = $_SESSION['isLoggedIn'];
      $this->userType = $_SESSION['userType'];
      $this->userName = $_SESSION['userName'];
    } else {
      unset($_SESSION['userId']);
      unset($_SESSION['isLoggedIn']);
      unset($_SESSION['userType']);
      unset($_SESSION['userName']);
    }
  }

  //Perform login using Cookie
  private function loginByCookie() {

    //unset credentials
    $this->userId = -1;
    $this->isLoggedIn = false;
    $this->userType = null;
    $this->userName = null;
    $this->messages = '';
    unset($_SESSION['userId']);
    unset($_SESSION['isLoggedIn']);
    unset($_SESSION['userType']);
    unset($_SESSION['userName']);

    if (isset($_COOKIE['remindme'])) {
      list ($token, $cookiehash) = explode(':', $_COOKIE['remindme']);
      if ($cookiehash == hash('sha256', $token . $this->cookieHashSecret) && !empty($token)) {
        if($this->userId == -1) {
          //check cookie token for doctors
          $query = "SELECT doctors_id AS id, doctors_surname + ' ' + doctors_name AS name FROM doctors WHERE doctors_token = " . $this->mssql_escape($token);
          $mssqlResult = mssql_query($query, $this->mssqlConnection);
          if($row = mssql_fetch_array($mssqlResult)) {

            //set vars
            $this->userId = $row['id'];
            $this->isLoggedIn = true;
            $this->userType = 'D';
            $this->userName = $row['name'];

            //set sessions
            $_SESSION['userId'] = $this->userId;
            $_SESSION['isLoggedIn'] = $this->isLoggedIn;
            $_SESSION['userType'] = $this->userType;
            $_SESSION['userName'] = $this->userName;

            //set the new token and last login
            $newtoken = hash('sha256', mt_rand());
            $query = "UPDATE doctors SET doctors_token = " . $this->mssql_escape($newtoken) . ", doctors_lastlogin = GETDATE() WHERE doctors_id = " . (int)$this->userId;
            mssql_query($query, $this->mssqlConnection);
            setcookie('remindme', $newtoken . ':' . hash('sha256', $newtoken . $this->cookieHashSecret), time() + $this->cookieTime);
          }          
        }
        if($this->isPatientLoginEnabled && $this->userId == -1) {
          //check cookie token for patients
          $query = "SELECT patients_id AS id, patients_surname + ' ' + patients_name AS name FROM patients WHERE patients_token = " . $this->mssql_escape($token);
          $mssqlResult = mssql_query($query, $this->mssqlConnection);
          if($row = mssql_fetch_array($mssqlResult)) {

            //set vars
            $this->userId = $row['id'];
            $this->isLoggedIn = true;
            $this->userType = 'P';
            $this->userName = $row['name'];

            //set sessions
            $_SESSION['userId'] = $this->userId;
            $_SESSION['isLoggedIn'] = $this->isLoggedIn;
            $_SESSION['userType'] = $this->userType;
            $_SESSION['userName'] = $this->userName;

            //set the new token and last login
            $newtoken = hash('sha256', mt_rand());
            $query = "UPDATE patients SET patients_token = " . $this->mssql_escape($newtoken) . ", patients_lastlogin = GETDATE() WHERE patients_id = " . (int)$this->userId;
            mssql_query($query, $this->mssqlConnection);
            setcookie('remindme', $newtoken . ':' . hash('sha256', $newtoken . $this->cookieHashSecret), time() + $this->cookieTime);
          }      
        }
      }
    }

    if(!$this->isLoggedIn) {
    	//delete the invalid cookie
      setcookie('remindme', false, time() - (3600 * 3650));
    }

    return $this->isLoggedIn;
  }

  //Perform login using POST
  private function loginByPost($username, $password, $remindme) {

    //unset credentials
    $this->userId = -1;
    $this->isLoggedIn = false;
    $this->userType = null;
    $this->userName = null;
    $this->messages = '';
    unset($_SESSION['userId']);
    unset($_SESSION['isLoggedIn']);
    unset($_SESSION['userType']);
    unset($_SESSION['userName']);

    if (!empty($username) && !empty($password)) {
      if($this->userId == -1) {
        //check username and password for doctors
        $query = "SELECT doctors_id AS id, doctors_surname + ' ' + doctors_name AS name FROM doctors WHERE doctors_username = " . $this->mssql_escape($username) . " AND doctors_password  = " . $this->mssql_escape($password);
        $mssqlResult = mssql_query($query, $this->mssqlConnection);
        if($row = mssql_fetch_array($mssqlResult)) {

          //set vars
          $this->userId = $row['id'];
          $this->isLoggedIn = true;
          $this->userType = 'D';
          $this->userName = $row['name'];

          //set sessions
          $_SESSION['userId'] = $this->userId;
          $_SESSION['isLoggedIn'] = $this->isLoggedIn;
          $_SESSION['userType'] = $this->userType;
          $_SESSION['userName'] = $this->userName;

          if($remindme) {
            //set the new token
            $newtoken = hash('sha256', mt_rand());
            $query = "UPDATE doctors SET doctors_token = " . $this->mssql_escape($newtoken) . ", doctors_lastlogin = GETDATE() WHERE doctors_id = " . (int)$this->userId;
            mssql_query($query, $this->mssqlConnection);
            setcookie('remindme', $newtoken . ':' . hash('sha256', $newtoken . $this->cookieHashSecret), time() + $this->cookieTime);
          } else {
            //update last login
            $query = "UPDATE doctors SET doctors_token = NULL, doctors_lastlogin = GETDATE() WHERE doctors_id = " . (int)$this->userId;
            mssql_query($query, $this->mssqlConnection);
          }
        }          
      }
      if($this->isPatientLoginEnabled && $this->userId == -1) {
        //check username and password for patients
        $query = "SELECT patients_id AS id, patients_surname + ' ' + patients_name AS name FROM patients WHERE patients_username = " . $this->mssql_escape($username) . " AND patients_password  = " . $this->mssql_escape($password);
        $mssqlResult = mssql_query($query, $this->mssqlConnection);
        if($row = mssql_fetch_array($mssqlResult)) {

          //set vars
          $this->userId = $row['id'];
          $this->isLoggedIn = true;
          $this->userType = 'P';
          $this->userName = $row['name'];

          //set sessions
          $_SESSION['userId'] = $this->userId;
          $_SESSION['isLoggedIn'] = $this->isLoggedIn;
          $_SESSION['userType'] = $this->userType;
          $_SESSION['userName'] = $this->userName;

          if($remindme) {
            //set the new token
            $newtoken = hash('sha256', mt_rand());
            $query = "UPDATE patients SET patients_token = " . $this->mssql_escape($newtoken) . ", patients_lastlogin = GETDATE() WHERE patients_id = " . (int)$this->userId;
            mssql_query($query, $this->mssqlConnection);
            setcookie('remindme', $newtoken . ':' . hash('sha256', $newtoken . $this->cookieHashSecret), time() + $this->cookieTime);
          } else {
            //update last login
            $query = "UPDATE patients SET patients_token = NULL, patients_lastlogin = GETDATE() WHERE patients_id = " . (int)$this->userId;
            mssql_query($query, $this->mssqlConnection);
          }
        }      
      }
    }

    if($this->isLoggedIn)
      $this->messages = $this->lang_loginsuccess;
    else
      $this->messages = $this->lang_loginerror;
    return $this->isLoggedIn;
  }
    
  //Perform logout
  private function logout() {

    //delete token
    if($this->userType == 'D') {
      $query = "UPDATE doctors SET doctors_token = NULL, doctors_lastlogin = NULL WHERE doctors_id = " . (int)$this->userId;
      mssql_query($query, $this->mssqlConnection);
    } else if($this->userType == 'P') {
      $query = "UPDATE patients SET patients_token = NULL, patients_lastlogin = NULL WHERE patients_id = " . (int)$this->userId;
      mssql_query($query, $this->mssqlConnection);  
    }

    //unset credentials
    $this->userId = -1;
    $this->isLoggedIn = false;
    $this->userType = null;
    $this->userName = null;
    $this->messages = $this->lang_logoutsuccess;
    unset($_SESSION['userId']);
    unset($_SESSION['isLoggedIn']);
    unset($_SESSION['userType']);
    unset($_SESSION['userName']);
    setcookie('remindme', false, time() - (3600 * 3650));
  }
}

