@echo off

rem Add custom options to the git config file
rem Copyright (c) Davide Gironi, 2015

setlocal 

cd ..
rem add your git custom options to the file loaded
if not exist .\_DevTools\config.git-setconfigoptions.bat exit
call .\_DevTools\config.git-setconfigoptions.bat

endlocal

exit
