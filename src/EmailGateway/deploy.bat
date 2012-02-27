@echo off
cls
REM netsh http add urlacl url=http://+:8080/ user=Everyone 
REM powershell -ExecutionPolicy RemoteSigned -noLogo -NonInteractive -File .\install-packages.ps1
REM "..\..\tools\FAKE\Fake.exe" build.fsx BuildApp
cd %~dp0
"%~dp0\..\..\tools\FAKE\Fake.exe" %~dp0\deploy.fsx
%~dp0\DeployToLocalAzure.bat