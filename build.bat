@echo off
cls
powershell -ExecutionPolicy RemoteSigned -noLogo -NonInteractive -File .\install-packages.ps1
'"tools\FAKE\Fake.exe" build.fsx
pause