@echo off

rem Copy License folder from solution folder to a destination path
rem Copyright (c) Davide Gironi, 2014

rem config parameters
set DESTPATH=Working\Bin\License\
set LICENSEFOLDER=..\License

rem copy
if not exist %LICENSEFOLDER% exit
xcopy %LICENSEFOLDER% %DESTPATH% /s /e /y

exit
