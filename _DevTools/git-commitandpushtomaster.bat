@echo off

rem Commit and push to master
rem Copyright (c) Davide Gironi, 2015

setlocal 

cd ..
git commit -am "updated by script"
git push

endlocal

exit
