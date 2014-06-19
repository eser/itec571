<%@ Page Title="Purchased Items" Language="C#" AutoEventWireup="true" CodeBehind="PurchasedItems.aspx.cs" Inherits="BulletinReader.PurchasedItems" MasterPageFile="~/Layout.Master" Async="true" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

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
                <asp:BoundField DataField="Article.Title" HeaderText="Article" SortExpression="Article" Visible="true" />
                <asp:BoundField DataField="Article.Author.Name" HeaderText="Author" SortExpression="Author" Visible="true" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" Visible="true" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" Visible="true" />
            </Columns>
        </asp:GridView>

        <div class="well" runat="server" id="NoRecords" visible="false">
            No records found
        </div>
    </div>
</asp:Content>
