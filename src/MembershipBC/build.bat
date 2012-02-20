@echo off
cls
REM netsh http add urlacl url=http://+:8080/ user=Everyone 
REM powershell -ExecutionPolicy RemoteSigned -noLogo -NonInteractive -File .\install-packages.ps1
REM "..\..\tools\FAKE\Fake.exe" build.fsx BuildApp
"..\..\tools\FAKE\Fake.exe" build.fsx Clean
"..\..\tools\FAKE\Fake.exe" buildmembershipviewmodels.fsx Clean
pause