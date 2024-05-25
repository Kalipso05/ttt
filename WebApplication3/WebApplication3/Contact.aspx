<%@ Page Async="true" Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebApplication3.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="source/styles/style/modylestyle.css" />
    <div class="container">
        <div class="header">
            <div class="logo">
                <asp:Image ID="imgLogo" runat="server" CssClass="logo-img" ImageUrl="source/styles/images/logo.png" />

                <p class="empty-p"></p>
                <asp:Label ID="txbFio" runat="server" Text="ФИО" CssClass="fio"></asp:Label>
                <asp:Image ID="imgUserPhoto" runat="server" CssClass="user-photo" ImageUrl="source/styles/images/logo.png" />
            </div>
        </div>
        <div class="left-bar">
            <div class="menu">
                <p>
                    <asp:Button ID="Button1" runat="server" Text="Библиотека корпоративных материалов" CssClass="text-wrap" BackColor="Green" />
                </p>
            </div>
        </div>

        <div class="center-bar">
            <div class="notification">
                <asp:Label ID="labelNotification1" runat="server" Text="Оповещение 1" CssClass="bordered-label"></asp:Label>
                <asp:Label ID="labelNotification2" runat="server" Text="Оповещение 2" CssClass="bordered-label"></asp:Label>
                <asp:Label ID="labelNotification3" runat="server" Text="Оповещение 3" CssClass="bordered-label"></asp:Label>
            </div>
            <div class="event">
                <asp:Label ID="labelEvent1" runat="server" Text="Событие 1" CssClass="bordered-label"></asp:Label>
                <asp:Label ID="labelEvent2" runat="server" Text="Событие 2" CssClass="bordered-label"></asp:Label>
                <asp:Label ID="labelEvent3" runat="server" Text="Событие 3" CssClass="bordered-label"></asp:Label>
            </div>
        </div>
        <div class="search">
            <input type="text" placeholder="Окно поиска">
        </div>
        <div class="mini-news">
        </div>



        <div class="footer-bar">
            <div class="calendar">

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:ListBox ID="ListBox1" runat="server" Width="500"></asp:ListBox>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>

        </div>

        <div class="test">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" OnLoad="DropDownList1_Load" AutoPostBack="true">
                    </asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
            <div>

                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="ButtonUpload" runat="server" Text="UpLoad" OnClick="ButtonUpload_Click"/>
            </div>

        </div>

    </div>
</asp:Content>
