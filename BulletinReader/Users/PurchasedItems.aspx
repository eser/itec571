<%@ Page Title="Purchased Items" Language="C#" AutoEventWireup="true" CodeBehind="PurchasedItems.aspx.cs" Inherits="BulletinReader.Users.PurchasedItems" MasterPageFile="~/Layout.Master" Async="true" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<%@ Import Namespace="BulletinReader.DataClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Purchased Items <small>Details of your purchase history</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" AllowSorting="false" UseAccessibleHeader="true" CssClass="table table-hover table-striped" GridLines="None">
            <RowStyle CssClass="cursor-pointer" />
            <Columns>
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
                <asp:TemplateField HeaderText="Status" SortExpression="Status">
                    <ItemTemplate>
                        <%# (Container.DataItem as PurchasedItem).TransactionDate %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" Visible="true" />
            </Columns>
            
        </asp:GridView>

        <div class="well" runat="server" id="NoRecords" visible="false">
            No records found
        </div>
    </div>
</asp:Content>
