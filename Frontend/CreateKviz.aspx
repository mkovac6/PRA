<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="CreateKviz.aspx.cs" Inherits="Frontend.CreateKviz" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/CustomEdit.css" rel="stylesheet" />
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
    <div class="container">
        <div id="divKviz">
            <asp:Label runat="server" ID="lblNazivKivza" Text="Naziv kviz:" meta:resourcekey="lblNazivKivzaResource1"></asp:Label>
            <asp:TextBox runat="server" ID="txtNazivKviza" CssClass="form-control" meta:resourcekey="txtNazivKvizaResource1"></asp:TextBox>
            <br />
            <asp:Button runat="server" ID="btnKreirajKviz" Text="Kreiraj kviz" OnClick="btnKreirajKviz_Click" CssClass="btn btn-secondary" meta:resourcekey="btnKreirajKvizResource1" />
        </div>
        <div id="divOdgovoriIPitanja" runat="server" visible="false">
            <table>
                <tr>
                    <td>
                        <div class="form-group">
                            <asp:Label runat="server" ID="lblPitanje" meta:resourcekey="lblPitanjeResource1">Pitanje</asp:Label>
                            <asp:TextBox runat="server" ID="txtP" CssClass="form-control" meta:resourcekey="txtPResource1"></asp:TextBox>
                            <asp:Label>Trajanje</asp:Label>
                            <asp:TextBox min="10" max="300" TextMode="Number" runat="server" ID="txtT" CssClass="form-control" meta:resourcekey="txtTResource1"></asp:TextBox>
                            <br />
                            <asp:Button runat="server" ID="btnAdd" Text="Dodaj" OnClick="btnAdd_Click" CssClass="btn btn-info" meta:resourcekey="btnAddResource1" />
                        </div>
                    </td>
                    <td>
                        <div class="form-group" id="divOdgovor" runat="server">
                            <asp:Label runat="server" ID="lblOdgovor" meta:resourcekey="lblOdgovorResource1">Odgovor</asp:Label>
                            <asp:TextBox runat="server" ID="txtOdgovor" CssClass="form-control" meta:resourcekey="txtOdgovorResource1"></asp:TextBox>
                            <asp:Label>Točan</asp:Label>
                            <br />
                            <asp:CheckBox runat="server" ID="cbTocan" CssClass="form-control" meta:resourcekey="cbTocanResource1" />
                            <br />
                            <asp:Button runat="server" ID="btnAddOdgovor" Text="Dodaj Odgovor" OnClick="btnAddOdgovor_Click" CssClass="btn btn-secondary" meta:resourcekey="btnAddOdgovorResource1" />
                        </div>
                    </td>
                </tr>



                <tr>
                    <td>
                        <div class="container my-container love">
                            <asp:PlaceHolder runat="server" ID="plc"></asp:PlaceHolder>
                        </div>
                    </td>

                </tr>


                <tr>
                    <td>

                        <div class="container">
                            <asp:Button CommandArgument='<%# Eval("IDKviz") %>' ID="btnSaveKviz" runat="server" Text="Spremi" OnClick="btnSaveKviz_Click" CssClass="btn btn-secondary" />
                        </div>
                        <div class="container">
                            <asp:Button CommandArgument='<%# Eval("IDKviz") %>' ID="btnNatrag" runat="server" Text="< Natrag" OnClick="btnNatrag_Click" CssClass="btn btn-outline-secondary" />
                        </div>

                    </td>
                </tr>
            </table>


        </div>
    </div>


</asp:Content>
