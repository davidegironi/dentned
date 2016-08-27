@echo off

rem Copy Document to a destination path
rem Copyright (c) Davide Gironi, 2015

rem set destination path
set DESTPATH=Working\%1

rem copy
if exist "%DESTPATH%" xcopy ..\INSTALL "%DESTPATH%" /v /y
if exist "%DESTPATH%" xcopy ..\README.md "%DESTPATH%" /v /y
if exist "%DESTPATH%\DentneD" xcopy ..\README.md "%DESTPATH%\DentneD" /v /y

exit
