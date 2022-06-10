<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="IgranjeKvizaAutor.aspx.cs" Inherits="Frontend.IgranjeKvizaAutor" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/Prijava.css" rel="stylesheet" />
    <link href="Content/CSS.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="divFlex">
            <div class="dviTable">
                <asp:Label ID="lblKod" runat="server"  CssClass="font-weight-bold doBorder" Font-Size="100px" meta:resourcekey="lblKodResource1"></asp:Label>
                <asp:Label ID="lblText" runat="server" Text="Pin for your game" Font-Size="100px" meta:resourcekey="lblTextResource1"></asp:Label>
            </div>
        </div>
        <div>
            <asp:PlaceHolder ID="pHolder"  runat="server"></asp:PlaceHolder>
        </div>
        <div class="mb-5 ml-5 QuizKontrola">
            <asp:Button ID="btnRefresh" runat="server" Text="Refresh quiz" CssClass="btn btn-info" meta:resourcekey="btnRefreshResource1" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancel quiz" OnClick="btnCancel_Click" CssClass="btn btn-danger" meta:resourcekey="btnCancelResource1" />
            <asp:Button ID="btnStart" runat="server" Text="Start quiz" OnClick="btnStart_Click" CssClass="btn btn-success" meta:resourcekey="btnStartResource1" />
        </div>
    </div>
</asp:Content>
