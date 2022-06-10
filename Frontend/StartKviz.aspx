<%@ Page Title="" Language="C#" MasterPageFile="~/SiteMaster.Master" AutoEventWireup="true" CodeBehind="StartKviz.aspx.cs" Inherits="Frontend.StartKviz" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/jquery-3.0.0.js"></script>

    <script>
        function startTimer(duration, display) {
            var timer = duration, seconds;
            setInterval(function () {

                seconds = duration--;


                seconds = seconds < 10 ? "0" + seconds : seconds;

                display.textContent = seconds;

                if (--seconds < 0) {
                    window.location = "SomePage.aspx";
                }
            }, 1000);
        }

        window.onload = function () {

            var fiveMinutes = 60 * 5,
                display = document.getElementById("<%=time.ClientID%>");
            console.log(display);
            var num = parseInt(display.textContent);
            startTimer(num, display);
        };
    </script>
    <link href="Content/Prijava.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <div class="MojNaslov">
            <asp:Label ID="LabelText" runat="server" Text="Label" meta:resourcekey="LabelTextResource1"></asp:Label>
        </div>
        <div Class="MojTimer">
            <asp:Label ID="time" runat="server" Text="Label"  meta:resourcekey="timeResource1"></asp:Label>
        </div>
        <div runat="server" id="odgovorPlaceholder" class="ButtonContainer">
            <div class="ButtonGrid">
                <asp:Button ID="Button0" runat="server" Text="Button" CssClass="btn btn-danger MojButton" meta:resourcekey="Button0Resource1" />
                <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-primary MojButton" meta:resourcekey="Button1Resource1"></asp:Button>
                <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btn btn-warning MojButton" meta:resourcekey="Button2Resource1" />
                <asp:Button ID="Button3" runat="server" Text="Button" CssClass="btn btn-success MojButton" meta:resourcekey="Button3Resource1" />
            </div>
        </div>
    </div>

</asp:Content>
