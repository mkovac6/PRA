<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="ReturnToAutor.aspx.cs" Inherits="Frontend.ReturnToAutor" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="Label1" runat="server" Text="Kviz gotov" meta:resourcekey="Label1Resource1"></asp:Label>
        <asp:Button ID="btnDone" runat="server" CssClass="btn btn-success" Text="Vrate se na pocetni ekran" OnClick="btnDone_Click" meta:resourcekey="btnDoneResource1" />
    </div>
</asp:Content>
