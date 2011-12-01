<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OffersView.aspx.cs" Inherits="LifeMap.Membership.Rest.Views.OffersView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!--<script type="text/javascript" src="/Scripts/jquery-1.4.1.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            ready();
        });

        function ready() {
            $.getJSON("http://localhost:16258/offers?jsoncallback=jsonCallback", function (json) { jsonCallback(json); });
        }

        function jsonCallback(json) {
            var offers = jQuery.parseJSON(json);
            jQuery.each(offers, function () {
                $(form1).add('<br/><input type="radio" name="offer" value="' + this.Id +  '"/>' + this.ProductName + ' ' + this.TermDescription + ' ' + this.BillingDescription);
            });
        }

    </script>-->
</head>
<body>

    <form id="form1" runat="server">
    <div>
    Select an offer
    <input name="OfferId" value="" />
    <input type="hidden" name="registrationId" value="<%= Resource.RegistrationId %>" />
    <input type="submit" />
    </div>
    </form>
</body>
</html>
