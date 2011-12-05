<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationView.aspx.cs" Inherits="LifeMap.Membership.Rest.Views.RegistrationView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%= Resource.FirstName %> <%= Resource.LastName %>
    <br />Email Address<%= Resource.EmailAddress %>
    <br />Offer Id: <%= Resource.OfferId %>
    <br />User Name: <%= Resource.UserName %>
    <br />Password: <%= Resource.Password %>
    <br />Name on card: <%= Resource.NameOnCard %>
    <br />Card number: <%= Resource.CardNumber %>
    <br />Cvv: <%= Resource.CvvNumber %>

    <br />Expiration Date: <%= Resource.ExpirationDate %>
    <% foreach (var link in Resource.Links)
       {%>
       <a href="<%= link.Uri %>"><%= link.Description %></a> 
    <% } %>
    </div>
    </form>
</body>
</html>
