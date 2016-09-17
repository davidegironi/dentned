@echo off

rem Restore an MSSQL database from a tsql file
rem Copyright (c) Davide Gironi, 2014

rem config parameters
set SQLCMD="Tools\SQLCmd\Binn\sqlcmd.exe"
set SOURCEPATH=..\_DBDump

rem check local source folder
for /f "tokens=*" %%A in ('cd') do set HERE=%%A
if not exist "%HERE%\%SOURCEPATH%" exit
	
setlocal enabledelayedexpansion

rem load configs
for %%f in (..\..\_DevTools\config.dbsql-backup*.bat) do (
	rem load config file
	call "%%f"
		
	echo Press R to restore the !SQLDATABASE! on !SQLHOSTNAME! server, your actual database will be dropped.
	echo Press B to backup your actual database then restore the !SQLDATABASE! on !SQLHOSTNAME! server.
	echo Prese any other key to skip to the next backup
	set /P INPUT=
	if "!INPUT!"=="r" goto:Restore
	if "!INPUT!"=="R" goto:Restore
	if "!INPUT!"=="b" goto:RestoreBackup
	if "!INPUT!"=="B" goto:RestoreBackup
	goto:Skip
	
	:RestoreBackup
	echo Performing !SQLDATABASE! backup...
	
	rem set autentication mode
	set OPTAUT=-E
	if not "!SQLUSERNAME!"=="" (
		if not "!SQLPASSWORD!"=="" (
			set OPTAUT=-U "!SQLUSERNAME!" -P "!SQLPASSWORD!"
		)
	)
		
	rem set output file
	set SQLFILE=!SQLDATABASE!_resbak.bak
	
	rem delete previous backup
	if exist "!SQLBAKFOLDR!\!SQLFILE!" del "!SQLBAKFOLDR!\!SQLFILE!"
		
	rem run backup
	%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -Q "BACKUP DATABASE !SQLDATABASE! TO DISK = N'!SQLFILE!' WITH NAME = N'!SQLDATABASE! Database Backup', INIT, NOSKIP;"
	
	:Restore
	echo Performing !SQLDATABASE! restoration...

	rem set autentication mode
	set OPTAUT=-E
	if not "!SQLUSERNAME!"=="" (
		if not "!SQLPASSWORD!"=="" (
			set OPTAUT=-U "!SQLUSERNAME!" -P "!SQLPASSWORD!"
		)
	)
	
	rem set input file
	set SQLFILERES=!SQLDATABASE!.bak

	rem delete previous backup
	if exist "!SQLBAKFOLDR!\!SQLFILERES!" del "!SQLBAKFOLDR!\!SQLFILERES!"
	
	rem local to backup folder
	copy "%HERE%\%SOURCEPATH%\!SQLFILERES!" "!SQLBAKFOLDR!\!SQLFILERES!"
		
	rem run restore
	%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -Q "IF EXISTS (SELECT name FROM master.sys.databases WHERE name = N'!SQLDATABASE!') BEGIN ALTER DATABASE !SQLDATABASE! SET single_user WITH ROLLBACK IMMEDIATE; DROP DATABASE !SQLDATABASE!; END"
	%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -Q "RESTORE DATABASE !SQLDATABASE! FROM DISK = N'!SQLDATABASE!.bak' WITH REPLACE"

	rem purge server backup
	if exist "!SQLBAKFOLDR!\!SQLFILERES!" del "!SQLBAKFOLDR!\!SQLFILERES!"
	
	:Skip
	echo ...
)

endlocal

pause

exit
