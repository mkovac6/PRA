<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KrajKvizaIgrac.aspx.cs" Inherits="Frontend.KrajKvizaIgrac" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
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
            <div>
                <asp:Label ID="lblQuiz" runat="server" Font-Size="50" Text="Kviz gotov." meta:resourcekey="lblQuizResource1"></asp:Label>
            </div>
            <div>
                <asp:Button ID="btnExit" runat="server" Text="Exit" OnClick="btnExit_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </form>
</body>
</html>