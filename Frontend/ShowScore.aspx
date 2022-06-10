<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowScore.aspx.cs" Inherits="Frontend.ShowScore" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
            <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/Prijava.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="centerDiv">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="font-weight-bold" Font-Size="150px" meta:resourcekey="Label1Resource1"></asp:Label>
            </div>
            <div class="mb-4">
                <asp:Button ID="btnRefresh" runat="server" Text="Refresh" CssClass="btn btn-warning"  OnClick="btnRefresh_Click" meta:resourcekey="btnRefreshResource1"/>
            </div>
            <div class="mb-4">
                <asp:Button ID="btnOdustani" runat="server" Text="Odustani" CssClass="btn btn-danger" OnClick="btnOdustani_Click" meta:resourcekey="btnOdustaniResource1" />
            </div>
        </div>
    </form>
</body>
</html>
