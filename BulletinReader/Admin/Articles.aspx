<%@ Page Title="Purchases" Language="C#" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="BulletinReader.Admin.Articles" MasterPageFile="~/Layout.Master" Async="true" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<%@ Import Namespace="BulletinReader.DataClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Articles <small>Shows all articles in the system</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <div class="form-group">
            <label for="FilterAuthor">Filter Author</label>
            <asp:DropDownList ID="FilterAuthor" runat="server" ClientIDMode="Static" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="FilterAuthor_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <asp:GridView ID="GridView" runat="server" AutoGenerateColumns="false" AllowSorting="false" UseAccessibleHeader="true" CssClass="table table-hover table-striped" GridLines="None">
            <RowStyle CssClass="cursor-pointer" />
            <Columns>
                <asp:TemplateField HeaderText="Review" SortExpression="Review">
                    <ItemTemplate>
                        <%# this.GetArticleCover(Container.DataItem as Article) %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Title" SortExpression="Title">
                    <ItemTemplate>
                        <a href='<%# FriendlyUrl.Href("~/Article", (Container.DataItem as Article).Title) %>'><%# (Container.DataItem as Article).Title %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Author" SortExpression="Author">
                    <ItemTemplate>
                        <a href='<%# FriendlyUrl.Href("~/Author", (Container.DataItem as Article).Author.Name) %>'><%# (Container.DataItem as Article).Author.Name %></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Review" SortExpression="Review">
                    <ItemTemplate>
                        <%# (Container.DataItem as Article).Review %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Publish Date" SortExpression="PublishDate">
                    <ItemTemplate>
                        <%# (Container.DataItem as Article).PublishDate.ToShortDateString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Store Date" SortExpression="StoreDate">
                    <ItemTemplate>
                        <%# (Container.DataItem as Article).StoreDate.ToShortDateString() %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div class="btn-group pull-right">
                            <asp:Button ID="btnRemoveArticle" runat="server" Text="Remove" CssClass="confirmation btn btn-danger btn-sm" CommandArgument='<%# (Container.DataItem as Article).ArticleId %>' OnClick="btnRemoveArticle_Click" />
                            <a href="<%: FriendlyUrl.Href("~/Admin/ArticlesEdit") %>?id=<%# (Container.DataItem as Article).ArticleId %>" class="btn btn-warning btn-sm">Edit</a>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>

        <div class="well" runat="server" id="NoRecords" visible="false">
            No records found
        </div>

        <div class="text-center">
            <a href="<%: FriendlyUrl.Href("~/Admin/ArticlesAdd") %>" class="btn btn-lg btn-primary">Add a New Article</a>
        </div>
    </div>
</asp:Content>
