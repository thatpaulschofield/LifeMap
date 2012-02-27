Option Explicit
Dim iisSmtpServer, relayIpList, domainObject, newDomain,alias

alias = "LifeMap.cloudapp.net"
' Create an instance of the SmtpServer object that represents the default smtp server.
Set iisSmtpServer = GetObject("IIS://localhost/smtpsvc/1")
' Get the current relay ip list
Set relayIpList = iisSmtpServer.Get("RelayIpList")
' Set to allow only specified ip addresses
relayIpList.GrantByDefault = false
relayIpList.IpGrant = "127.0.0.1"
' Save the settings
iisSmtpServer.Put "RelayIpList",RelayIpList
iisSmtpServer.SetInfo
' Get the smtp server domain object
Set domainObject = GetObject("IIS://LocalHost/SMTPSVC/1/domain")
' Create the aliases
Set newDomain = domainObject.Create ("IIsSmtpDomain",alias)

' Set the route action to be an ALIAS domain
newDomain.RouteAction = 16
newDomain.RouteActionString = alias
' Save the settings
newDomain.SetInfo