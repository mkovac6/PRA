<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WaitOthersToJoin.aspx.cs" Inherits="Frontend.WaitOthersToJoin" culture="auto" meta:resourcekey="PageResource2" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <script src="Scripts/jquery-3.0.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link href="Content/Prijava.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="centerDiv">
            
            <asp:Label CssClass="text-capitalize font-weight-bold " runat="server" ID="lblText" Text="Wait for others to join" meta:resourcekey="lblTextResource1"></asp:Label>
            <div class="divFlex">
                <asp:Button ID="btnRefreshPage" runat="server" Text="Refersh page" CssClass="btn btn-primary" OnClick="btnRefreshPage_Click" meta:resourcekey="btnRefreshPageResource1" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" OnClick="btnCancel_Click" meta:resourcekey="btnCancelResource1"/>
            </div>
        </div>
    </form>
</body>
</html>
