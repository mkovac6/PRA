<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="KrajKviza.aspx.cs" Inherits="Frontend.KrajKviza" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div>
            <asp:Label ID="lblKraj" runat="server" Text="Kraj"></asp:Label>
        </div>
        <div>
            <asp:PlaceHolder ID="pHolder" runat="server"></asp:PlaceHolder>
        </div>
        <div>
            <asp:Button ID="btnExit" runat="server" Text="Exit" Width="200px" OnClick="btnExit_Click" CssClass="btn btn-primary"/>
        </div>
    </div>
</asp:Content>
