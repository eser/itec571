<%@ Page Title="Purchases" Language="C#" AutoEventWireup="true" CodeBehind="Purchases.aspx.cs" Inherits="BulletinReader.Admin.Purchases" MasterPageFile="~/Layout.Master" Async="true" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<%@ Import Namespace="BulletinReader.DataClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Purchases <small>Shows all purchase transactions</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <div class="form-group">
            <label for="FilterStatus">Filter Status</label>
            <asp:DropDownList ID="FilterStatus" runat="server" ClientIDMode="Static" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="FilterStatus_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" AllowSorting="false" UseAccessibleHeader="true" CssClass="table table-hover table-striped" GridLines="None">
            <RowStyle CssClass="cursor-pointer" />
            <Columns>
                <asp:TemplateField HeaderText="User" SortExpression="User">
                    <ItemTemplate>
                        <a href='mailto:<%# (Container.DataItem as PurchasedItem).User.Email %>'><%# (Container.DataItem as PurchasedItem).User.UserName %></a>
                        ( <%# (Container.DataItem as PurchasedItem).User.Fullname %> )
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Article" SortExpression="Article">
                    <ItemTemplate>
                        <a href='<%# FriendlyUrl.Href("~/Article", (Container.DataItem as PurchasedItem).Article.Title) %>'><%# (Container.DataItem as PurchasedItem).Article.Title %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author" SortExpression="Author">
                    <ItemTemplate>
                        <a href='<%# FriendlyUrl.Href("~/Author", (Container.DataItem as PurchasedItem).Article.Author.Name) %>'><%# (Container.DataItem as PurchasedItem).Article.Author.Name %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                    <ItemTemplate>
                        <%# ((Container.DataItem as PurchasedItem).Status == PurchasedItemStatus.NotConfirmed) ? "Not Confirmed" : "Confirmed" %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Transaction Date" SortExpression="TransactionDate">
                    <ItemTemplate>
                        <%# (Container.DataItem as PurchasedItem).TransactionDate %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnChangeConfirmationStatus" runat="server" Text="Change Confirmation Status" CssClass="confirmation btn btn-default btn-sm pull-right" CommandArgument='<%# (Container.DataItem as PurchasedItem).PurchasedItemId %>' OnClick="btnChangeConfirmationStatus_Click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

        <div class="well" runat="server" id="NoRecords" visible="false">
            No records found
        </div>
    </div>
</asp:Content>
