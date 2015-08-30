@echo off

rem DentneD Database backup script
rem Copyright (c) Davide Gironi, 2015

rem set mssql database hostname
set SQLHOSTNAME=192.168.1.57
rem set mssql database name
set SQLDATABASE=dentned
rem set mssql database username
set SQLUSERNAME=sa
rem set mssql database password
set SQLPASSWORD=123456
rem set database backup folder
set SQLFOLDER=\\%SQLHOSTNAME%\Backup
rem optionally set a copy timeout time for the backup file
set SQLCOPYTIMEOUT=30

rem set the destination full path of backup files
set DESTPATH=d:\Projects VS\DentneD\DentneD\DentneD\backup\data

rem purge backup files in older than days
set OLDFILEDAYSPURGE=30

rem set binary, use full path or run this script from the script folder
set DATE=tools\UnxUtils\date.exe
set FIND=tools\UnxUtils\find.exe
set SQLCMD=tools\SQLCmd\Binn\SQLCMD.EXE
