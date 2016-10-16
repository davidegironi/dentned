@echo off

rem perform delete over all tables, exept reports
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; DECLARE @sql NVARCHAR(max)=''; SELECT @sql += 'DELETE FROM [' + name + ']; ' FROM sys.Tables WHERE name NOT IN ('reports'); EXEC sp_executesql @sql; EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all;'"

rem reseed all tables
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "EXEC sp_msforeachtable 'DBCC CHECKIDENT(''?'', RESEED, 0)';"
rem reseed counting records for reports
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "DECLARE @max int; SELECT @max = MAX(reports_id) from reports; DBCC CHECKIDENT('reports', RESEED, @max);"
rem reseed counting records for contactstypes
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "DECLARE @max int; SELECT @max = MAX(contactstypes_id) from contactstypes; DBCC CHECKIDENT('contactstypes', RESEED, @max);"
rem reseed counting records for patientsattributestypes
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "DECLARE @max int; SELECT @max = MAX(patientsattributestypes_id) from patientsattributestypes; DBCC CHECKIDENT('patientsattributestypes', RESEED, @max);"

rem add system contactstypes
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "INSERT INTO contactstypes(contactstypes_name) VALUES('EMail');"
rem add system patientsattributestypes
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "INSERT INTO patientsattributestypes(patientsattributestypes_name) VALUES('SendAppointmentsReminder');"
