<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prijava.aspx.cs" Inherits="Frontend.Prijava" UnobtrusiveValidationMode="None" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
            <div class="container">
                <div>
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" meta:resourcekey="lblEmailResource1"></asp:Label>
                    <asp:TextBox ID="txtEmail" Width="250px" runat="server" BorderColor="#CCCCCC"
                        BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" CssClass="form-control" ForeColor="#333333" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtEmail" ValidationGroup="Group1" Display="Dynamic"
                        ErrorMessage="Niste upisali email" Font-Bold="True" ForeColor="Red" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                        ControlToValidate="txtEmail" ValidationGroup="Group1" Display="Dynamic"
                        ErrorMessage="Krivo upisana e-mail adresa" Font-Bold="True" ForeColor="Red"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="RegularExpressionValidator2Resource1">*</asp:RegularExpressionValidator>
                </div>
                <div>
                    <asp:Label ID="lblLozinka" runat="server" Text="Lozinka:" meta:resourcekey="lblLozinkaResource1"></asp:Label>
                    <asp:TextBox ID="txtLozinka" Width="250px" runat="server" BorderColor="#CCCCCC"
                        BorderStyle="Solid" BorderWidth="1px" TextMode="Password" Font-Bold="True" CssClass="form-control" ForeColor="#333333" meta:resourcekey="txtLozinkaResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtLozinka" ValidationGroup="Group1" Display="Dynamic"
                        ErrorMessage="Niste upisali Ime" Font-Bold="True" ForeColor="Red" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
                </div>

                <div class="divBtn">
                    <br />
                    <asp:Button runat="server" Width="250px" ValidationGroup="Group1" OnClick="btnSubmit_Click" ID="btnSubmit" CssClass="btn btn-danger" Text="Prijava" meta:resourcekey="btnSubmitResource1" />
                    <br />
                    <asp:LinkButton runat="server" ID="btnRegister" Text="Register"  CssClass="btn-link" PostBackUrl="~/Registracija.aspx" meta:resourcekey="btnRegisterResource1"  ></asp:LinkButton>
                    <br />
                </div>
                <div>
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" Font-Bold="False"
                        Font-Size="12px"  ForeColor="Red" meta:resourcekey="ValidationSummaryResource1" />
                </div>
            </div>
        </div>

    </form>
</body>
</html>
