@echo off

rem Clean data folders
rem Copyright (c) Davide Gironi, 2014

rd ..\DataTemp\Attachmentsdir /s /q
md ..\DataTemp\Attachmentsdir

rd ..\DataTemp\Datadir /s /q
md ..\DataTemp\Datadir

rd ..\DataTemp\Invoices /s /q
md ..\DataTemp\Invoices

rd ..\DataTemp\Temp /s /q
md ..\DataTemp\Temp

exit
