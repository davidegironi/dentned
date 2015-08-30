<?php
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

define('_VALID_', 1);

require ('config.inc.php');

session_start();

header ("Expires: Mon, 1 Jan 1997 01:00:00 GMT");
header ("Last-Modified: " . gmdate("D, d M Y H:i:s") . " GMT");
header ("Cache-Control: no-cache,max-age=0,must-revalidate");
header ("Pragma: no-cache");

//errors display
if ($enableErrorDisplay) {
  error_reporting(E_ALL);
  ini_set('display_errors', 1);
}

//load language
include ("lang/".$language.".php");

//load functions
include ("functions.php");

//open db connection
$mssqlConnection = mssql_pconnect($mssql_hostname, $mssql_username, $mssql_password)
  or die("Couldn't connect to SQL Server."); 
$mssqlDatabase = mssql_select_db($mssql_database, $mssqlConnection)
  or die("Couldn't open database."); 

//set the login class
$login = new Login($mssqlConnection, $isPatientLoginEnabled, $cookieHashSecret, $cookieTime, $tokenPurgeTime, $lang['LOGIN_LOGINSUCCESS'], $lang['LOGIN_LOGINERROR'], $lang['LOGIN_LOGOUTSUCCESS']);

//perfor requests
if(isset($_GET['ajax']) && $_GET['ajax'] == "1") {
  if(isset($_GET['f']) && in_array($_GET['f'], $registered_functions))
    call_user_func($_GET['f']);
} else {
  //main page
  include('page_main.php');
}

//close db connection
mssql_close($mssqlConnection);

?>