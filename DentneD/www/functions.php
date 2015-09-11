<?php
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

//set here the ajax registered functions
$registered_functions = array('events');

//List all events
function events() {
  global $mssql, $patientEventShowDoctorName, $lang, $login;

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
  CONVERT(varchar(25), a.appointments_from) AS start,
  CONVERT(varchar(25), a.appointments_to) AS [end],
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
  $query .= " CAST(a.appointments_from AS date) >= CAST('". (isset($_GET['start']) ? date('Y-m-d', strtotime(strval($_GET['start']))) : '1970-01-01') . "' AS date) AND CAST(a.appointments_from AS date) <= CAST('". (isset($_GET['end']) ? date('Y-m-d', strtotime(strval($_GET['end']))) : '1970-01-01') . "' AS date)";
  
  $mssqlData = $mssql->fetchData($query);
  foreach ($mssqlData as $row) {
    $events_array[] = array(
      'id' => $row['id'],
      'title' => $row['title'],
      'description' =>
        (!empty($row['notes']) ? $row['notes'] . '<br/>' : '') .
        '<b>' . $lang['MODALEVENT_PERIOD'] . '</b>: ' . date("Y/m/d H:i", strtotime(strval($row['start']))) . ' - ' . date("H:i", strtotime(strval($row['end']))) . '<br/>' .
        ($isLoginDoctor ? '<b>'.$lang['MODALEVENT_ROOM'].'</b>: ' . $row['room'] . '<br/>' : '') .
        ($isLoginDoctor ? '<b>'.$lang['MODALEVENT_PATIENT'].'</b>: ' . $row['patient'] . '<br/>' : '') .
        ($isLoginPatient && $patientEventShowDoctorName ? '<b>'.$lang['MODALEVENT_DOCTOR'].'</b>: ' . $row['doctor'] . '<br/>' : ''),
      'start' => date("Y/m/d H:i:s", strtotime(strval($row['start']))),
      'end' => date("Y/m/d H:i:s", strtotime(strval($row['end']))),
      'allDay' => false
    );
  }
  
  echo json_encode($events_array);
}

