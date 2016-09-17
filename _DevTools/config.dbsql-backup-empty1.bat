@echo off

rem perform delete over all tables, exept reports
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'; DECLARE @sql NVARCHAR(max)=''; SELECT @sql += 'DELETE FROM [' + name + ']; ' FROM sys.Tables WHERE name NOT IN ('reports'); EXEC sp_executesql @sql; EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all;'"

rem reseed all tables, reseed reports counting records
%SQLCMD% -S !SQLHOSTNAME! !OPTAUT! -d "!SQLDATABASE!" -Q "EXEC sp_msforeachtable 'DBCC CHECKIDENT(''?'', RESEED, 0)'; DECLARE @max int; SELECT @max = MAX(reports_id) from reports; DBCC CHECKIDENT('reports', RESEED, @max);"
