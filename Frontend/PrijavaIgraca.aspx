<%@ Page Language="C#" UnobtrusiveValidationMode="None" AutoEventWireup="true" CodeBehind="PrijavaIgraca.aspx.cs" Inherits="Frontend.PrijavaIgraca" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Prijava igrača</title>
    <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/Prijava.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
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
        <div  class="centerDiv">
            <div class="container" id="divAlert" runat="server" visible="false">
                <div class="alert alert-danger alert-dismissible" id="myAlert">
                    <a href="#" class="close">&times;</a>
                    <asp:Label runat="server" ID="txtAlert" meta:resourcekey="txtAlertResource1"></asp:Label>
                </div>
            </div>
            <div class="container mb-4">
                <asp:Label ID="lblUserName" runat="server" Text="Upisite nadimak:" meta:resourcekey="lblUserNameResource1"></asp:Label>
            </div>
            <div class="container  mb-4">
                <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control" meta:resourcekey="txtUserNameResource1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName" runat="server" meta:resourcekey="RequiredFieldValidator1Resource1"></asp:RequiredFieldValidator>
            </div>
            <div class="container divBtn mb-4" >
                <asp:Button ID="btnAdd" Width="250px" runat="server" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-light button" meta:resourcekey="btnAddResource1" />
            </div>
        </div>
    </form>
</body>
</html>
