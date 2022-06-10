<%@ Page Language="C#" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="KodKviza.aspx.cs" Inherits="Frontend.KodKviza" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Prijava.css" rel="stylesheet" />
    <script>
        $(document).ready(function () {
            $(".close").click(function () {
                $("#myAlert").alert("close");
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="centerDiv">
            <div class="container" id="divAlert" runat="server" visible="false">
                <div class="alert alert-danger alert-dismissible" id="myAlert">
                    <a href="#" class="close">&times;</a>
                    <asp:Label runat="server" ID="txtAlert" meta:resourcekey="txtAlertResource1"></asp:Label>
                </div>
            </div>
            <div class="container mb-4">
                <asp:Label ID="lblKod" runat="server" Text="Upisite kod:" meta:resourcekey="lblKodResource1" ></asp:Label>
            </div>
            <div class="container mb-4">
                <asp:TextBox runat="server" ID="txtKod" CssClass="form-control" meta:resourcekey="txtKodResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtKod" runat="server" ErrorMessage="RequiredFieldValidator" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
            </div>
            <div class="divBtn mb-4">
                <asp:Button ID="Button1" runat="server" Text="Insert" CssClass="btn btn-light button" OnClick="Button1_Click1" meta:resourcekey="Button1Resource1" />
            </div>

        </div>
    </form>
</body>
</html>
