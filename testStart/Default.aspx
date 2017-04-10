<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="jquery-3.1.1.min.js"></script>
    <script src="https://beautiful.start.payfort.com/checkout.js"></script>
<script>
    $(function () {

        //// Initialize Start on page load
        //StartCheckout.config({
        //    key: "test_open_k_3a4fb497cc9d0c8c86a4",
        //    complete: function (params) {
        //        alert(params.token.id);
        //        $("#hdToken").val(params.token.id);

        //    }
        //});

        //StartCheckout.open({
        //    amount: 10000,  // = AED 100.00
        //    currency: "AED",
        //    email: "john.doe@gmail.com"
        //});
    });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:HiddenField runat="server" ID="hdToken" />
        <asp:Button runat="server" ID="btnTest" Text="Submit" OnClick="btnTest_Click" />
    </div>
    </form>
</body>
</html>
