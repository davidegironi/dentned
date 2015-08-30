<?php
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

//set timezone
date_default_timezone_set('Europe/Rome');

//set page baseurl
$baseuri = "http://localhost/dentned";

//set database credentials
$mssql_hostname = '192.168.1.57';
$mssql_database = 'dentned';
$mssql_username = 'sa';
$mssql_password = '123456';

//set language
$language = 'en';

//set calendar startpage (month, agendaWeek, agendaDay)
$calendarStartPage = 'agendaWeek';

//set calendar scrolltime
$calendarScrollTime = '08:00:00';

//enable or disable patient login
$isPatientLoginEnabled = false;

//show doctor name to patient
$patientEventShowDoctorName = true;

//set the login cookie secret key
$cookieHashSecret = 'a982SokLA';

//set the login cookie expire time (in seconds)
$cookieTime = 3600*24*60; //60 days

//set the login token purge time (in days)
$tokenPurgeTime = 60;

//enable error display
$enableErrorDisplay = false;

?>