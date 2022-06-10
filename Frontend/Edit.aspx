<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Frontend.Edit" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            $(".close").click(function () {
                $("#myAlert").alert("close");
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" id="divAlert" runat="server" visible="false">
        <div class="alert alert-danger alert-dismissible" id="myAlert">
            <a href="#" class="close">&times;</a>
            <asp:Label runat="server" ID="txtAlert" meta:resourcekey="txtAlertResource1"></asp:Label>
        </div>
    </div>

    <div class="container edit-container">
        <div class="form-group">
            <asp:Label Text="Text" runat="server" ID="lblTkest" meta:resourcekey="lblTkestResource1" />
            <asp:TextBox runat="server" ID="txtTekst" CssClass="form-control" meta:resourcekey="txtTekstResource1" />
        </div>
        <div class="form-group">
            <asp:Label Text="Description" runat="server" ID="lblTocan" meta:resourcekey="lblTocanResource1" />
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" meta:resourcekey="RadioButtonList1Resource1">
                <asp:ListItem id="tocan" Value="true" meta:resourcekey="ListItemResource1">Točan</asp:ListItem>
                <asp:ListItem id="neTocan" Value="false" meta:resourcekey="ListItemResource2">Ne točan</asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <asp:Button Text="Save" ID="btnSave" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" meta:resourcekey="btnSaveResource1" />
    </div>
</asp:Content>
