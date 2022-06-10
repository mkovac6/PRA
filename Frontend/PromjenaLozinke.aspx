<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="PromjenaLozinke.aspx.cs" Inherits="Frontend.PromjenaLozinke" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:Label ID="lblText" runat="server" Text="Label" meta:resourcekey="Promijenite lozinku"></asp:Label>
           <div>
                 <asp:Label ID="lblLozinka" runat="server" Text="Lozinka:" meta:resourcekey="lblLozinkaResource1"></asp:Label>
                 <asp:TextBox ID="txtLozinka" Width="250px" runat="server" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" TextMode="Password" BorderWidth="1px" Font-Bold="True" CssClass="form-control" ForeColor="#333333" meta:resourcekey="txtLozinkaResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtLozinka" Display="Dynamic" 
                        ErrorMessage="Niste upisali Ime" Font-Bold="True" ForeColor="Red" meta:resourcekey="RequiredFieldValidator2Resource1">*</asp:RequiredFieldValidator>
             </div>
            <div>
                <asp:Label runat="server" ID="lblPotvrdaLozinke" Text="Potvrdi lozinku:" meta:resourcekey="lblPotvrdaLozinkeResource1"></asp:Label>
                <asp:TextBox ID="txtLozinkaPotvrda" runat="server" CssClass="form-control" BorderColor="#CCCCCC" 
                        BorderStyle="Solid" BorderWidth="1px" Font-Bold="True" ForeColor="#333333" 
                        TextMode="Password" meta:resourcekey="txtLozinkaPotvrdaResource1"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtLozinkaPotvrda" Display="Dynamic" 
                        ErrorMessage="Niste upisali potvrdu lozinke" Font-Bold="True" 
                        ForeColor="Red" meta:resourcekey="RequiredFieldValidator7Resource1">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" 
                        ControlToCompare="txtLozinka" ControlToValidate="txtLozinkaPotvrda" 
                        Display="Dynamic" ErrorMessage="Lozinke u oba polja moraju odgovarati" 
                        Font-Bold="True" ForeColor="Red" meta:resourcekey="CompareValidator3Resource1">*</asp:CompareValidator>
            </div>
        <div>
            <asp:Button CssClass="btn btn-success" ID="btnSave" runat="server" Text="DONE" OnClick="btnSave_Click" />
        </div>
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
    </div>
</asp:Content>
