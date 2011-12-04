<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationsView.aspx.cs" Inherits="LifeMap.Membership.Rest.Views.RegistrationsView" %>
<%@ Import Namespace="LifeMap.Membership.Commands" %>
<%@ Import Namespace="LifeMap.Membership.Rest.Resources" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<table>
    <%
        foreach (var registration in Resource)
{
%>
<tr>
    <td><a href="<%= registration.CreateUri() %>"><%= registration.FirstName + " " + registration.LastName %></a></td>
    <td><%= registration.EmailAddress %></td>
</tr>
<%  
}
%>
</table>
<a href="<%= new StartRegistration().CreateUri() %>">Register</a>
</body>
</html>
