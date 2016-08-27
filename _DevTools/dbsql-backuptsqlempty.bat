@echo off

rem Backup an MSSQL database to a tsql file, run empty commands
rem Copyright (c) Davide Gironi, 2014

dbsql-backuptsql.bat %1 empty
