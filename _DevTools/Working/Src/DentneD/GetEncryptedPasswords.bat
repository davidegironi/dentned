@echo off

set /p formprotectedpassword="Enter the password for Form protection: "
set /p reportprotectedpassword="Enter the password for Report protection: "

DentneD.exe -f %formprotectedpassword% -t %reportprotectedpassword%

pause
