<?php
// Copyright (c) 2015 Davide Gironi
//
// Please refer to LICENSE file for licensing information.

defined( '_VALID_' ) or die( 'Restricted access' );

//MSSQL connection handler class
class MSSQLWrapper {
  protected $connection = null;
  protected $driver = 'sqlsrv';
  
  //MSSQL wrapper constructor
  public function __construct($driver, $hostname, $database, $username, $password) {
    $this->driver = $driver;
    if(!$this->connect($hostname, $database, $username, $password))
      die("Couldn't connect to SQL Server."); 
  }
  
  //Open a connection
  public function connect($hostname, $database, $username, $password) {
    if($this->driver == 'sqlsrv') {
      $this->connection = sqlsrv_connect($hostname, array( "Database"=>$database, "UID"=>$username, "PWD"=>$password));
      if(!$this->connection)
        return false;
    } else if($this->driver == 'mssql') {
      $this->connection = mssql_pconnect($hostname, $username, $password);
      if(!$this->connection)
        return false;
      if(!mssql_select_db($database, $this->connection))
        return false; 
    }
    return true;
  }
  
  //Close a connection
  public function close() {
    if($this->driver == 'sqlsrv') {
      sqlsrv_close($this->connection);
    } else if($this->driver == 'mssql') {
      mssql_close($this->connection);
    }
  }
  
  //Perform a query
  public function query($query) {
    if($this->driver == 'sqlsrv') {
      $result = sqlsrv_query($this->connection, $query);
    } else if($this->driver == 'mssql') {
      $result = mssql_query($query, $this->connection);
    }
    return $result;
  }
  
  //Fetch some data
  public function fetchData($query) {
    $data_array = array();
    $result = $this->query($query);
    if($this->driver == 'sqlsrv') {
      while ($row = sqlsrv_fetch_array($result)) {
        $data_array[] = $row;                          
      }
    } else if($this->driver == 'mssql') {
      while ($row = mssql_fetch_array($result)) {
        $data_array[] = $row;                          
      }
    }    
    return $data_array;           
  }
  
  //MSSQL escape characters
  public function escape($data) {
    if(is_numeric($data))
      return $data;
    $unpacked = unpack('H*hex', $data);
    return '0x' . $unpacked['hex'];
  }

}
