<?php
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

//Login handler class
//reference: https://github.com/panique/php-login-advanced by Panique
class login {
  public $userId = -1;
  public $isLoggedIn = false;
  public $userType = null;
  public $userName = null;
  public $messages = '';

  private $mssql = null;
  private $isPatientLoginEnabled = false;
  private $cookieHashSecret = '123456';
  private $cookieTime = 5184000;
  private $tokenPurgeTime = 60;
  private $lang_loginsuccess = 'You have been successfully logged in.';
  private $lang_loginerror = 'Can not log in.';
  private $lang_logoutsuccess = 'You have been successfully logged out.';

  //Login constructor
  public function __construct($mssql, $isPatientLoginEnabled, $cookieHashSecret, $cookieTime, $tokenPurgeTime, $lang_loginsuccess, $lang_loginerror, $lang_logoutsuccess) {
    
    //set variables
    $this->mssql = $mssql;
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
    $this->mssql->query($query);
    if($this->isPatientLoginEnabled) {
      $query = "UPDATE patients SET patients_token = NULL, patients_lastlogin = NULL WHERE patients_lastlogin < DATEADD(day, " . -(int)$this->tokenPurgeTime. ", GETDATE())";
      $this->mssql->query($query);  
    }
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
          $query = "SELECT doctors_id AS id, doctors_surname + ' ' + doctors_name AS name FROM doctors WHERE doctors_token = " . $this->mssql->escape($token);
          $mssqlData = $this->mssql->fetchData($query);
          foreach ($mssqlData as $row) {

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
            $query = "UPDATE doctors SET doctors_token = " . $this->mssql->escape($newtoken) . ", doctors_lastlogin = GETDATE() WHERE doctors_id = " . (int)$this->userId;
            $this->mssql->query($query);
            setcookie('remindme', $newtoken . ':' . hash('sha256', $newtoken . $this->cookieHashSecret), time() + $this->cookieTime);
          }          
        }
        if($this->isPatientLoginEnabled && $this->userId == -1) {
          //check cookie token for patients
          $query = "SELECT patients_id AS id, patients_surname + ' ' + patients_name AS name FROM patients WHERE patients_token = " . $this->mssql->escape($token);
          $mssqlData = $this->mssql->fetchData($query);
          foreach ($mssqlData as $row) {

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
            $query = "UPDATE patients SET patients_token = " . $this->mssql->escape($newtoken) . ", patients_lastlogin = GETDATE() WHERE patients_id = " . (int)$this->userId;
            $this->mssql->query($query);
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
        $query = "SELECT doctors_id AS id, doctors_surname + ' ' + doctors_name AS name FROM doctors WHERE doctors_username = " . $this->mssql->escape($username) . " AND doctors_password  = " . $this->mssql->escape($password);
        $mssqlData = $this->mssql->fetchData($query);
        foreach ($mssqlData as $row) {

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
            $query = "UPDATE doctors SET doctors_token = " . $this->mssql->escape($newtoken) . ", doctors_lastlogin = GETDATE() WHERE doctors_id = " . (int)$this->userId;
            $this->mssql->query($query);
            setcookie('remindme', $newtoken . ':' . hash('sha256', $newtoken . $this->cookieHashSecret), time() + $this->cookieTime);
          } else {
            //update last login
            $query = "UPDATE doctors SET doctors_token = NULL, doctors_lastlogin = GETDATE() WHERE doctors_id = " . (int)$this->userId;
            $this->mssql->query($query);
          }
        }          
      }
      if($this->isPatientLoginEnabled && $this->userId == -1) {
        //check username and password for patients
        $query = "SELECT patients_id AS id, patients_surname + ' ' + patients_name AS name FROM patients WHERE patients_username = " . $this->mssql->escape($username) . " AND patients_password  = " . $this->mssql->escape($password);
        $mssqlData = $this->mssql->fetchData($query);
        foreach ($mssqlData as $row) {

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
            $query = "UPDATE patients SET patients_token = " . $this->mssql->escape($newtoken) . ", patients_lastlogin = GETDATE() WHERE patients_id = " . (int)$this->userId;
            $this->mssql->query($query);
            setcookie('remindme', $newtoken . ':' . hash('sha256', $newtoken . $this->cookieHashSecret), time() + $this->cookieTime);
          } else {
            //update last login
            $query = "UPDATE patients SET patients_token = NULL, patients_lastlogin = GETDATE() WHERE patients_id = " . (int)$this->userId;
            $this->mssql->query($query);
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
      $this->mssql->query($query);
    } else if($this->userType == 'P') {
      $query = "UPDATE patients SET patients_token = NULL, patients_lastlogin = NULL WHERE patients_id = " . (int)$this->userId;
      $this->mssql->query($query);  
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
