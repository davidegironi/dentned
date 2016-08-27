@echo off

rem Backup an MSSQL database to a tsql file
rem Copyright (c) Davide Gironi, 2014

rem config parameters
set SQLCMD="Tools\SQLCmd\Binn\sqlcmd.exe"
set DESTPATH=Working\%1\_DBDump

rem set local backup folder
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
	set SQLFILE=!SQLDATABASE!.bak

	rem delete previous backup
	if exist "!SQLBAKFOLDR!\!SQLFILE!" del "!SQLBAKFOLDR!\!SQLFILE!"

	rem set autentication mode
	set OPTAUT=-E
	if not "!SQLUSERNAME!"=="" (
		if not "!SQLPASSWORD!"=="" (
			set OPTAUT=-U "!SQLUSERNAME!" -P "!SQLPASSWORD!"
		)
	)

	rem run empty commands
	if "%2"=="empty" (
		rem check if emptu command exists and run
		if exist "%%~nf-empty.bat" call %%~nf-empty.bat
	)
	
	rem run backup
	%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -Q "BACKUP DATABASE !SQLDATABASE! TO DISK = N'!SQLFILE!' WITH NAME = N'!SQLDATABASE! Database Backup', INIT, NOSKIP;"

	rem wait a little
	timeout /t !SQLBAKCPTIM!

	rem copy to local folder
	copy "!SQLBAKFOLDR!\!SQLFILE!" "%HERE%\%DESTPATH%\!SQLFILE!"

	rem purge server backup
	if exist "!SQLBAKFOLDR!\!SQLFILE!" del "!SQLBAKFOLDR!\!SQLFILE!"
)

endlocal

exit
