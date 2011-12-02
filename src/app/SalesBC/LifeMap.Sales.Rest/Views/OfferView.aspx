<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferView.aspx.cs" Inherits="LifeMap.Hosts.Rest.Views.Sales.OfferView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Product ID: <input name="ProductId" value="<%= Guid.NewGuid().ToString() %>" />
        <br />Duration in days: <input name="DurationInDays" value="<%= 10 %>"/>
        <br />Valid from: <input name="ValidFrom" value="1/1/2010" />
        <br />Valid to: <input name="ValidTo" value="1/1/2020" />
        <input type="submit" />
    </div>
    </form>
</body>
</html>
