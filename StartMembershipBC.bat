start "Membership Host Service" "src\MembershipBC\bin\MembershipHostService\NServiceBus.Host.exe"  NServiceBus.Integration
start "Membership View Host Service" "src\MembershipBC\bin\MembershipViewHostService\NServiceBus.Host.exe"  NServiceBus.Integration
start "Membership Rest Service" "tools\IisExpress\iisexpress.exe" /path:C:\projects\LifeMap\src\MembershipBC\app\LifeMap.Membership.Rest /port:53363