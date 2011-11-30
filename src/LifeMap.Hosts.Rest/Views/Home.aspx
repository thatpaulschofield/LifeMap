<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LifeMap.Hosts.Rest.Views.Home" %>
<%@ Import Namespace="LifeMap.Membership.Commands" %>
<%@ Import Namespace="LifeMap.Security.Rest.Resources" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <a href="<%= new LogIn().CreateUri() %>">Log in</a>
    <a href="<%= new StartRegistration().CreateUri() %>">Sign up</a>
    </div>
    </form>
</body>
</html>
