@echo off

rem DentneD Database backup script
rem Copyright (c) Davide Gironi, 2015

rem set mssql database hostname
set SQLHOSTNAME=YOUR_DATABASE_HOSTNAME (es. localhost)
rem set mssql database name
set SQLDATABASE=YOUR_DATABASE_NAME (es. dentned)
rem set mssql database username
set SQLUSERNAME=YOUR_DATABASE_USERNAME (es. userdb)
rem set mssql database password
set SQLPASSWORD=YOUR_DATABASE_PASSWORD (es. userdbsecpas)
rem set database backup folder
set SQLFOLDER=YOUR_DATABASE_BACKUPFOLDER (es. c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\Backup)
rem optionally set a copy timeout time for the backup file
set SQLCOPYTIMEOUT=30

rem set the destination full path of backup files
set DESTPATH=data

rem purge backup files in older than days
set OLDFILEDAYSPURGE=30

rem set binary, use full path or run this script from the script folder
set DATE=tools\UnxUtils\date.exe
set FIND=tools\UnxUtils\find.exe
set SQLCMD=tools\SQLCmd\Binn\SQLCMD.EXE
