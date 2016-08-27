@echo off

rem Backup an MSSQL database (schema or complete) to a sql file
rem Copyright (c) Davide Gironi, 2014

rem config parameters
set SQLSERVERDUMP="Tools\SQLServerDump\sqlserverdump.exe"
set DESTPATH=Working\%1\_DBDump

rem set output file
for /f "tokens=*" %%A in ('cd') do set HERE=%%A
if not exist "%HERE%\%DESTPATH%" (
	mkdir "%HERE%\%DESTPATH%"
)

setlocal enabledelayedexpansion

rem load configs
for %%f in (..\..\_DevTools\config.dbsql-backup*.bat) do (
	rem load config file
	call "%%f"
	echo Performing !SQLDATABASE! backup...
	
	rem set output file
	set SQLFILE=%HERE%\%DESTPATH%\!SQLDATABASE!.sql
	if "%2"=="schema" (
		set SQLFILE=%HERE%\%DESTPATH%\!SQLDATABASE!-schema.sql
	)

	rem check for schema only backup
	set OPTNODATA=
	if "%2"=="schema" (
		set OPTNODATA=--no-data
	)

	rem set autentication mode
	set OPTAUTH=
	if not "!SQLUSERNAME!"=="" (
		if not "!SQLPASSWORD!"=="" (
			set OPTAUTH=--username="!SQLUSERNAME!" --password="!SQLPASSWORD!"
		)
	)

	rem run backup
	%SQLSERVERDUMP% !OPTNODATA! !OPTAUTH! --sql-engine --server-name="!SQLHOSTNAME!" --result-file="!SQLFILE!" "!SQLDATABASE!"
)

endlocal

exit
