<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="EditKviz.aspx.cs" Inherits="Frontend.EditKviz" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/CustomEdit.css" rel="stylesheet" />
    <link href="Content/pp.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-container love">
        <asp:PlaceHolder runat="server" ID="ph"></asp:PlaceHolder>
        
    </div>
    <div class="container my-container love">
        <asp:Button ID="Button1" runat="server" Text="Go back" OnClick="Button1_Click" CssClass="btn btn-primary" />
    </div>
</asp:Content>
