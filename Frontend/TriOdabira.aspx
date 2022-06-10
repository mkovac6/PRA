<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TriOdabira.aspx.cs" Inherits="Frontend.TriOdabira" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>KVIZOVSKI</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/CSS.css" rel="stylesheet" />
    <link href="Content/NewDesign.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="container grid-container">
                <div class="item1">
                    <asp:Button runat="server" ID="btnRegister" Text="Registracija" CssClass="btn btn-success" PostBackUrl="~/Registracija.aspx" meta:resourcekey="btnRegisterResource1"></asp:Button>
                </div>
                <div class="item2">
                    <asp:Button runat="server" ID="btnLogin" Text="Prijava" CssClass="btn btn-danger" PostBackUrl="~/Prijava.aspx" meta:resourcekey="btnLoginResource1"></asp:Button>
                </div>
                <div class="item3">
                    <asp:Button runat="server" ID="btnPlay" Text="Igraj" CssClass="btn btn-primary" PostBackUrl="~/KodKviza.aspx" meta:resourcekey="btnPlayResource1"></asp:Button>
                </div>
                <div class="myContainer">
                    <asp:Label Text="Jezik" runat="server" ID="lblJezik" CssClass="text-black-50 myText" meta:resourcekey="lblJezikResource1" />
                    <asp:DropDownList runat="server" ID="ddlJezik" OnSelectedIndexChanged="JezikChange" AutoPostBack="true" CssClass="form-control" meta:resourcekey="DropDownListResource1">
                        <asp:ListItem Text="--- Odabrei ---" Value="0" meta:resourcekey="ListItemResource1" />
                        <asp:ListItem Text="Hrvatski" Value="hr" meta:resourcekey="ListItemResource2" />
                        <asp:ListItem Text="English" Value="en" meta:resourcekey="ListItemResource3" />

                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <div class="footer">
            <asp:Label runat="server" ID="footer" Text=""> &COPY; Kvizovski</asp:Label>
        </div>
    </form>
</body>
</html>
