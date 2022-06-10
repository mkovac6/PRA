<%@ Page Language="C#" UnobtrusiveValidationMode="none" AutoEventWireup="true" CodeBehind="Registracija.aspx.cs" Inherits="Frontend.Registracija" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

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
            <div class="container" id="div1" runat="server" visible="false">
                <div class="alert alert-danger alert-dismissible" id="myAlert">
                    <a href="#" class="close">&times;</a>
                    <asp:Label runat="server" ID="Label1" meta:resourcekey="Label1Resource1"></asp:Label>
                </div>
            </div>
<div class="centerDiv">
    <div class="container" id="divAlert" runat="server" visible="false">
        <div class="alert alert-danger alert-dismissible" id="myAlert">
            <a href="#" class="close">&times;</a>
            <asp:Label runat="server" ID="txtAlert" meta:resourcekey="txtAlertResource1"></asp:Label>
        </div>
        </div>
    <div class="container" >
        <div> 
            <asp:Label ID="lblEmail" runat="server" Text="Email:" meta:resourcekey="lblEmailResource1"></asp:Label>        
            <asp:TextBox ID="txtEmail" Width="250px" runat="server" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" CssClass="form-control" ForeColor="#333333" meta:resourcekey="txtEmailResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtEmail" Display="Dynamic" 
                        ErrorMessage="Niste upisali email" Font-Bold="True" ForeColor="Red" meta:resourcekey="RequiredFieldValidator1Resource1">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtEmail" Display="Dynamic" 
                        ErrorMessage="Krivo upisana e-mail adresa" Font-Bold="True" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" meta:resourcekey="RegularExpressionValidator2Resource1">*</asp:RegularExpressionValidator>
         </div>  
            <div>
                <asp:Label runat="server" ID="lblIme" Text="Ime:" meta:resourcekey="lblImeResource1"></asp:Label>
                <asp:TextBox ID="txtIme" runat="server" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" CssClass="form-control" ForeColor="#333333" meta:resourcekey="txtImeResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtIme" Display="Dynamic" 
                        ErrorMessage="Niste upisali Ime" Font-Bold="True" ForeColor="Red" meta:resourcekey="RequiredFieldValidator3Resource1">*</asp:RequiredFieldValidator>

            </div>
            <div>
                <asp:Label runat="server" ID="lblPrezime" Text="Prezime:" meta:resourcekey="lblPrezimeResource1"></asp:Label>
                <asp:TextBox ID="txtPrezime" runat="server" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" CssClass="form-control" ForeColor="#333333" meta:resourcekey="txtPrezimeResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtPrezime" Display="Dynamic" 
                        ErrorMessage="Niste upisali Prezime" Font-Bold="True" ForeColor="Red" meta:resourcekey="RequiredFieldValidator4Resource1">*</asp:RequiredFieldValidator>

            </div>

             <div>
                 <asp:Label ID="lblLozinka" runat="server" Text="Lozinka:" meta:resourcekey="lblLozinkaResource1"></asp:Label>
                 <asp:TextBox ID="txtLozinka" Width="250px" runat="server" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" TextMode="Password" BorderWidth="1px" Font-Bold="True" CssClass="form-control" ForeColor="#333333" meta:resourcekey="txtLozinkaResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtLozinka" Display="Dynamic" 
                        ErrorMessage="Niste upisali Ime" Font-Bold="True" ForeColor="Red" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
             </div>
            <div>
                <asp:Label runat="server" ID="lblPotvrdaLozinke" Text="Potvrdi lozinku:" meta:resourcekey="lblPotvrdaLozinkeResource1"></asp:Label>
                <asp:TextBox ID="txtLozinkaPotvrda" runat="server" CssClass="form-control" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="#333333" 
                        TextMode="Password" meta:resourcekey="txtLozinkaPotvrdaResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtLozinkaPotvrda" Display="Dynamic" 
                        ErrorMessage="Niste upisali potvrdu lozinke" Font-Bold="True" 
                        ForeColor="Red" meta:resourcekey="RequiredFieldValidator7Resource1">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToCompare="txtLozinka" ControlToValidate="txtLozinkaPotvrda" 
                        Display="Dynamic" ErrorMessage="Lozinke u oba polja moraju odgovarati" 
                        Font-Bold="True" ForeColor="Red" meta:resourcekey="CompareValidator3Resource1">*</asp:CompareValidator>
            </div>
         <div class="divBtn">
                <br />
                <asp:Button runat="server" Width="250px" OnClick="btnSubmit_Click" ID="btnSubmit" CssClass="btn btn-danger" Text="Prijava" meta:resourcekey="btnSubmitResource1" />
                <br />
             </div>
        <div>
                    <asp:ValidationSummary ID="ValidationSummary" runat="server" Font-Bold="False" 
                        Font-Size="12px" ForeColor="Red" meta:resourcekey="ValidationSummaryResource1" />
            </div>
        </div>
    </div>
    
    </form>
</body>
</html>
