@echo off

rem Make dentned installation folders
rem Copyright (c) Davide Gironi, 2015

rem set destination path
set DESTPATH=Working\%1

move "%DESTPATH%\DentneD" "%DESTPATH%\Bin"
move "%DESTPATH%\Bin\www" "%DESTPATH%\www"
if not exist "%DESTPATH%\DentneD" mkdir "%DESTPATH%\DentneD"
move "%DESTPATH%\Bin" "%DESTPATH%\DentneD\Bin"
move "%DESTPATH%\License" "%DESTPATH%\DentneD\Bin\"
move "%DESTPATH%\www" "%DESTPATH%\DentneD-www"
move "%DESTPATH%\_DBDump" "%DESTPATH%\Install\"
if not exist "%DESTPATH%\DentneD\Data" mkdir "%DESTPATH%\DentneD\Data"
if not exist "%DESTPATH%\DentneD\Data\Attachments" mkdir "%DESTPATH%\DentneD\Data\Attachments"
if not exist "%DESTPATH%\DentneD\Data\Datas" mkdir "%DESTPATH%\DentneD\Data\Datas"
if not exist "%DESTPATH%\DentneD\Data\Invoices" mkdir "%DESTPATH%\DentneD\Data\Invoices"
if not exist "%DESTPATH%\DentneD\Temp" mkdir "%DESTPATH%\DentneD\Temp"

exit
