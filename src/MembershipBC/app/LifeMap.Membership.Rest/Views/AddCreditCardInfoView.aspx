<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddCreditCardInfoView.aspx.cs" Inherits="LifeMap.Membership.Rest.Views.AddCreditCardInfoView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <input type="hidden" name="Id" value="<%= Resource.Id %>" />
    <br />Name on card: <input name="NameOnCard" value="<%= Resource.NameOnCard %>" />
    <br />Card number: <input name="CardNumber" value="<%= Resource.CardNumber %>" />
    <br />CVV number: <input name="CvvNumber" value="<%= Resource.CvvNumber %>" />
    <br />Expiration date: <input name="ExpirationDate" value="<%= Resource.ExpirationDate %>" />
    <br /><input type="submit" />
    </div>
    </form>
</body>
</html>
