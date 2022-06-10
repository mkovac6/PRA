<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KvizInterrupted.aspx.cs" Inherits="Frontend.KvizInterrupted" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/NewDesign.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <asp:Label ID="lblText" runat="server" Font-Size="70" Text="Kviz was interrupted. Sign in again."></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnExit" runat="server" CssClass="btn btn-danger" OnClick="btnExit_Click" Text="Exit" />
        </div>
    </form>
</body>
</html>
