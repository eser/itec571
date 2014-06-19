<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="BulletinReader.Author" MasterPageFile="~/Layout.Master" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Browse</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Author <small><%= this.AuthorEntity.Name %></small></h1>
        </div>

        <asp:Repeater ID="ArticleRepeater" runat="server">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <!-- <img src="<%# Eval("CoverImagePath") %>" alt="<%# Eval("Title") %>" /> -->
                        <div class="caption">
                            <h3><%# Eval("Title") %></h3>
                            <p>
                                <em><%# Eval("Review") %></em></a>
                            </p>
                            <div class="pull-right">
                                <a href="<%# FriendlyUrl.Href("~/Article", Eval("Title")) %>" class="btn btn-default btn-sm" role="button">
                                    <%# this.IsAPurchasedItem((Guid)Eval("ArticleId")) ? "Read" : "Purchase" %>
                                </a>
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
