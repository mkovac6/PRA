<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="PromjernaKorisničkogRačuna.aspx.cs" Inherits="Frontend.PromjernaKorisničkogRačuna" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
    

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/KorisnickiRacunPromjena.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <div class="container d-flex p-2 d-flex justify-content-around">
         <table runat="server"  id="tbl" class="table-borderless table-responsive-md table-responsive-sm table-responsive-xl table-responsive-lg align-content-center align-self-lg-center ">
        <tr>
            <td>
                <asp:Label runat="server" ID="lblIme" Text="Ime:" meta:resourcekey="lblImeResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtIme" meta:resourcekey="txtImeResource1"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td>
                <asp:Label runat="server" ID="lblPrezime" Text="Prezime:" meta:resourcekey="lblPrezimeResource1"></asp:Label>
            </td>
            <td>
                <asp:TextBox runat="server" Id="txtPrezime" CssClass="form-control" meta:resourcekey="txtPrezimeResource1"></asp:TextBox>

            </td>
        </tr>
        <tr>
            <td colspan="1">
                <asp:Button runat="server" OnClick="btnPromjeni_Click" id="btnPromjeni" Text="Promjeni" cssClass="btn btn-danger button" meta:resourcekey="btnPromjeniResource1" />
            </td>
            
        </tr>
             <tr>
                  <td>
                     <asp:Button runat="server" OnClick="btnSendMail_Click" ID="btnSendMail" Text="Pošalji link na lozinku"  cssClass="btn btn-danger button" meta:resourcekey="btnSendMailResource1" ></asp:Button>
            </td>
             </tr>
    </table>
    </div>
</asp:Content>
