<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="SomePage.aspx.cs" Inherits="Frontend.SomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
            <asp:PlaceHolder ID="pHolder" runat="server"></asp:PlaceHolder>
        </div>
         <div>
            <asp:Button ID="btnOdustani" runat="server" Text="Odustani" CssClass="btn btn-danger" OnClick="btnOdustani_Click" />
        </div>
        <div>
            <asp:Button ID="btnNext" runat="server" Text="Novo pitanje" CssClass="btn btn-warning" OnClick="btnNext_Click" />
        </div>
    </div>
</asp:Content>
