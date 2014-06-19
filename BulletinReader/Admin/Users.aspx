<%@ Page Title="Users" Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="BulletinReader.Admin.Users" MasterPageFile="~/Layout.Master" Async="true" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<%@ Import Namespace="BulletinReader.DataClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Users <small>Shows all registered users</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" AllowSorting="false" UseAccessibleHeader="true" CssClass="table table-hover table-striped" GridLines="None">
            <RowStyle CssClass="cursor-pointer" />
            <Columns>
                <asp:TemplateField HeaderText="User Name" SortExpression="Username">
                    <ItemTemplate>
                        <a href='mailto:<%# (Container.DataItem as User).Email %>'><%# (Container.DataItem as User).UserName %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="E-mail" SortExpression="Email">
                    <ItemTemplate>
                        <%# (Container.DataItem as User).Email %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Full Name" SortExpression="Fullname">
                    <ItemTemplate>
                        <%# (Container.DataItem as User).Fullname %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone Number" SortExpression="PhoneNumber">
                    <ItemTemplate>
                        <%# (Container.DataItem as User).PhoneNumber %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address" SortExpression="Address">
                    <ItemTemplate>
                        <%# (Container.DataItem as User).Address %>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

        <div class="well" runat="server" id="NoRecords" visible="false">
            No records found
        </div>
    </div>
</asp:Content>
