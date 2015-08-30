@echo off

rem DentneD Database backup script
rem Copyright (c) Davide Gironi, 2015

echo ------------------------------
echo DentneD Database backup script
echo ------------------------------

rem load config
call config.db-backup.bat

rem set output folder
if not exist "%DESTPATH%" (
	mkdir "%DESTPATH%"
)

rem set short path
for /f "tokens=*" %%A in ("%DATE%") do (set DATE=%%~sA)
for /f "tokens=*" %%A in ("%FIND%") do (set FIND=%%~sA)
for /f "tokens=*" %%A in ("%SQLCMD%") do (set SQLCMD=%%~sA)

rem format current date
for /f "tokens=*" %%A in ('%DATE% +%%Y%%m%%d%%H%%M') do (set NOW=%%A)

rem set autentication mode
set OPTAUT=-E
if not "%SQLUSERNAME%"=="" (
	if not "%SQLPASSWORD%"=="" (
		set OPTAUT=-U "%SQLUSERNAME%" -P "%SQLPASSWORD%"
	)
)

rem run backup
%SQLCMD% -S %SQLHOSTNAME% %OPTAUT% -Q "BACKUP DATABASE %SQLDATABASE% TO DISK = N'%SQLDATABASE%.bak' WITH NAME = N'%SQLDATABASE% Database Backup', INIT, NOSKIP;"

rem wait a little
timeout /t %SQLCOPYTIMEOUT%

rem copy to local folder
copy "%SQLFOLDER%\%SQLDATABASE%.bak" "%DESTPATH%\%SQLDATABASE%_%NOW%.bak"

rem purge server backup
if exist "%SQLFOLDER%\%SQLDATABASE%.bak" del "%SQLFOLDER%\%SQLDATABASE%.bak"

rem purge old files
for /f "tokens=*" %%A in ('%FIND% "%DESTPATH%" -iname "*" -type f -mtime +%OLDFILEDAYSPURGE%') do (del "%%A")

exit
