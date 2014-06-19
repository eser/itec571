<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BulletinReader.Default" MasterPageFile="~/Layout.Master" Async="true" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Browse</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Browse <small>all articles in system</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <asp:Repeater ID="ArticleRepeater" runat="server">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col-sm-6 col-md-4">
                    <div class="thumbnail">
                        <img src="<%# Eval("CoverImagePath") %>" alt="<%# Eval("Title") %>" class="img-responsive" />
                        <div class="caption">
                            <h3><%# Eval("Title") %></h3>
                            <p>
                                <em><%# Eval("Review") %></em> - by <a href="<%# FriendlyUrl.Href("~/Author", Eval("Author.Name")) %>"><%# Eval("Author.Name") %></a>
                            </p>
                            <div class="pull-right">
                                <a href="<%# FriendlyUrl.Href("~/Article", Eval("Title")) %>" class="btn btn-default btn-sm" role="button">
                                    <%# this.GetPurchasedItem((Guid)Eval("ArticleId")) != null ? "Read" : "Purchase" %>
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
