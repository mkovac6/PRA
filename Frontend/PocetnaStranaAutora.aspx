<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="PocetnaStranaAutora.aspx.cs" Inherits="Frontend.PocetnaStranaAutora" Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>

        <div>
            <div>
                <table>
                    <tr>
                        <td style="padding: 10px">
                            <asp:Button CommandArgument='<%# Eval("IDKviz") %>' ID="btnLogOut" runat="server" Text="Log Out" Style="border: none" OnClick="btnLogOut_Click"
                                CssClass="btn btn-outline-secondary" />
                        </td>
                        <td style="padding: 10px">
                            <asp:Label ID="Email" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px">
                            <asp:Button CommandArgument='<%# Eval("IDKviz") %>' ID="btnChangeInfo" runat="server" Text="Change Info" Style="border: none" OnClick="btnChangeInfo_Click"
                                CssClass="btn btn-outline-secondary" />
                        </td>
                        <td></td>
                    </tr>
                </table>


            </div>
        </div>

        <div>
            <div class="container">
                <asp:Repeater runat="server" ID="rpOdgovori" ClientIDMode="Static">
                    <HeaderTemplate>
                        <table class="table table-sm table-striped myTable">
                            <tr class="thead-dark">
                                <th>Id</th>
                                <th>Naziv</th>
                                <th>Datum Izrade</th>
                                <th></th>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("IDKviz") %>

                            </td>
                            <td><%# Eval("Naziv") %></td>
                            <td>
                                <%# Eval("DatumIzrade") %>
                            </td>
                            <td>
                                <asp:Button CommandArgument='<%# Eval("IDKviz") %>' ID="btnUredi" runat="server" Text="Uredi kviz" OnClick="btnUredi_Click" CssClass="btn btn-outline-secondary" meta:resourcekey="btnUrediResource2" />
                                <asp:Button CommandArgument='<%# Eval("IDKviz") %>' ID="btnIgraj" runat="server" Text="Igraj kviz" OnClick="btnIgraj_Click" CssClass="btn btn-outline-secondary" meta:resourcekey="btnIgrajResource2" />
                                <asp:Button CommandArgument='<%# Eval("IDKViz") %>' ID="btnDelete" runat="server" Text="Izbrisi kviz" OnClick="btnDelete_Click" CssClass="btn btn-outline-danger" />
                                <%--dodaj meta--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div>
                <asp:Button runat="server" ID="btnCreateKviz" Text="Kreiraj kviz" CssClass="btn btn-primary" OnClick="btnCreateKviz_Click" meta:resourcekey="btnCreateKvizResource1" />
            </div>
        </div>

    </div>
</asp:Content>
