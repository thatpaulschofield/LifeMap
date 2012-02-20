@echo off
cls
netsh http add urlacl url=http://+:8080/ user=Everyone 
powershell -ExecutionPolicy RemoteSigned -noLogo -NonInteractive -File .\install-packages.ps1
'"tools\FAKE\Fake.exe" build.fsx
pause