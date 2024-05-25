<%@ Page Title="Home Page" Async="true" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" href="source/styles/style/styles.css" />
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
                    <asp:Button ID="Button1" runat="server" Text="Библиотека корпоративных материалов" CssClass="text-wrap" BackColor="Green" OnClick="OpenLabrary_Click" />
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

        <div class="news" id="labelsContainer" runat="server">
            <%--<asp:Label ID="Label1" runat="server" Text="Label" CssClass="bordered-label"></asp:Label>--%>


            <%--<asp:TextBox ID="txbNews" runat="server" Wrap="true" Height="60px" ReadOnly="true" Font-Size="16px" Width="200" TextMode="MultiLine" ></asp:TextBox>--%>
        </div>

        <div class="footer-bar">
            <div class="calendar">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:Calendar ID="Calendar1" runat="server" Height="210px" Width="351px" OnSelectionChanged="Calendar1_SelectionChanged">
                            <DayHeaderStyle BackColor="White" />
                            <DayStyle BackColor="White" />
                            <TitleStyle BackColor="Green" />
                            <NextPrevStyle BackColor="Green" />
                            <SelectedDayStyle BackColor="Red" />
                        </asp:Calendar>
                        <asp:Label ID="ContentLabel" runat="server" Visible="false"></asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

        </div>

        <div class="card" runat="server" visible="false">
            <p>fddf</p>
        </div>

    </div>
</asp:Content>
