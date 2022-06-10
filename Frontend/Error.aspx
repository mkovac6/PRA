<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Frontend.Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/CSS.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
             <nav class="navbar navbar-expand-lg navbar-light" style="background-color: white;">
                <a class="navbar-brand" href="#" style="font-size: large; font-weight: 900;">Kvizovski</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="Prijava.aspx">Login page</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Registracija.aspx">Registartion page</a>
                        </li>
                         <li class="nav-item">
                            <a class="nav-link" href="TriOdabira.aspx">Play kviz</a>
                        </li>
                    </ul>
                </div>
            </nav>
        <div class="container">
            <asp:Label runat="server" ID="lblError" Text="Oups... Error occured..."></asp:Label>
            <asp:Label runat="server" ID="lblServer"></asp:Label>
        </div>
        <asp:Button ID="btnGoBack" runat="server" Text="Go back" CssClass="btn btn-danger" />
    </form>
</body>
</html>
