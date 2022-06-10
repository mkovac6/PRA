<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KvizControl.ascx.cs" Inherits="Frontend.KvizControl" %>

<div class="card-body" id="divContainer" runat="server">

    <p>

        <div runat="server" id="conRead" visible="true">
            <table>
                <tr>
                     <td>
                        <asp:Label runat="server" ID="lblInfoTekst" Text="Tekst:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblText"></asp:Label>
                    </td>
                </tr>
                <tr>
                     <td>
                        <asp:Label runat="server" ID="lblInfoTrajanje" Text="Trajanje:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label runat="server" ID="lblTrajanje"></asp:Label>
                    </td>
                </tr>
            </table>



        </div>

        <div runat="server" id="conEdit" visible="false">
            <asp:TextBox ID="txtTekst" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:TextBox min="10" max="300" TextMode="Number" ID="txtTrajanje" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnUpdate" runat="server" Text="Spremi" OnClick="btnUpdate_Click" CssClass="btn btn-danger" />
        </div>
    </p>
    <div>

        <asp:Repeater runat="server" ID="rpOdgovori" ClientIDMode="Static">
            <HeaderTemplate>
                <table class="table table-sm table-striped myTable">
                    <tr class="thead-dark">
                        <th>Id</th>
                        <th>Text</th>
                        <th>Točan</th>
                        <th></th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td>
                        <%# Eval("IDOdgovor") %>
                          
                    </td>
                    <td><%# Eval("Tekst") %></td>
                    <td>
                        <%# Eval("Tocno") %>

                     

                    </td>
                    <td>
                        <asp:Button CommandArgument='<%# Eval("IDOdgovor") %>' ID="btnUredi" runat="server" Text="Uredi" OnClick="btnUredi_Click" CssClass="btn btn-outline-secondary" />
                        <asp:Button CommandArgument='<%# Eval("IDOdgovor") %>' ID="btnObrisi" runat="server" Text="Obriši" OnClick="btnObrisi_Click" CssClass="btn  btn-outline-danger" />
                    </td>

                </tr>

            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
        <div runat="server" id="btnHolder" visible="true">
            <asp:Button ID="btnUpdatePitanje" runat="server" AutoPostBack="flase" Text="Uredi" OnClick="btnUpdatePitanje_Click" CssClass="btn btn-dark" />
            <asp:Button ID="btndeletePitanje" runat="server" Text="Obriši pitanje" OnClick="btndeletePitanje_Click" CssClass="btn btn-primary" />

        </div>
    </div>
</div>
