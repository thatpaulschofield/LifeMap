start "Sales Host Service" "src\SalesBC\bin\SalesHostService\NServiceBus.Host.exe"  NServiceBus.Integration
start "Sales View Host Service" "src\SalesBC\bin\SalesViewHostService\NServiceBus.Host.exe"  NServiceBus.Integration
start "Sales Rest Service" "tools\IisExpress\iisexpress.exe" /path:C:\projects\LifeMap\src\SalesBC\app\LifeMap.Sales.Rest /port:16258