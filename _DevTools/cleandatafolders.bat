@echo off

rem Clean data folders
rem Copyright (c) Davide Gironi, 2014

rd ..\DataTemp\Attachments /s /q
md ..\DataTemp\Attachments

rd ..\DataTemp\Datas /s /q
md ..\DataTemp\Datas

rd ..\DataTemp\Invoices /s /q
md ..\DataTemp\Invoices

rd ..\DataTemp\Temp /s /q
md ..\DataTemp\Temp

exit
