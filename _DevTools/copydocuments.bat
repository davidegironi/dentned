@echo off

rem Copy Document to a destination path
rem Copyright (c) Davide Gironi, 2015

rem set destination path
set DESTPATH=Working\%1

rem copy
if not exist "%DESTPATH%\Install" mkdir "%DESTPATH%\Install"
if exist "%DESTPATH%" xcopy ..\INSTALL "%DESTPATH%\Install\" /v /y
if exist "%DESTPATH%" xcopy ..\README.md "%DESTPATH%" /v /y
if exist "%DESTPATH%\DentneD" xcopy ..\README.md "%DESTPATH%\DentneD" /v /y

exit
