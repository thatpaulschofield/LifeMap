﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginView.aspx.cs" Inherits="LifeMap.Membership.Rest.Views.LoginView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input name="RegistrationId" type="hidden" value="<%= Resource.RegistrationId %>" />
        <br /><input name="UserName" value="<%= Resource.UserName %>" />
        <br /><input name="Password" type="password" value="<%= Resource.Password %>" />
        <br /><input type="submit" />
    </div>
    </form>
</body>
</html>