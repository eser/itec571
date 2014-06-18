<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BulletinReader.Search" MasterPageFile="~/Layout.Master" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Browse</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Search <small><%= this.Query %></small></h1>
        </div>

        <asp:Repeater ID="ArticleRepeater" runat="server">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <!-- <img src="<%# Eval("Article.CoverImagePath") %>" alt="<%# Eval("Article.Title") %>" /> -->
                        <div class="caption">
                            <h3><%# Highlight((string)Eval("Article.Title")) %></h3>
                            <p>
                                <em><%# Highlight((string)Eval("Article.Review")) %></em> - by <a href="<%# FriendlyUrl.Href("~/Author", Eval("Author.Name")) %>"><%# Eval("Author.Name") %></a>
                            </p>
                            <div class="pull-right">
                                <a href="<%# FriendlyUrl.Href("~/Purchase", Eval("Article.ArticleId")) %>" class="btn btn-default btn-sm" role="button">Purchase</a>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>

        <ul class="pagination">
            <asp:Literal ID="ArticlePaging" runat="server" />
        </ul>
    </div>
</asp:Content>
