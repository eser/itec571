<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Article.aspx.cs" Inherits="BulletinReader.Article" MasterPageFile="~/Layout.Master" Async="true" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Browse</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Article <small><%= this.ArticleEntity.Title %> - by <a href="<%: FriendlyUrl.Href("~/Author", this.ArticleEntity.Author.Name) %>"><%= this.ArticleEntity.Author.Name %></a></small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <div class="row">
            <div class="col-md-3 col-lg-3 text-center">
                <img src="<%: this.ArticleEntity.CoverImagePath %>" alt="<%: this.ArticleEntity.Title %>" class="img-responsive" />
            </div>

            <div class=" col-md-9 col-lg-9">
                <table class="table table-article-information">
                    <tbody>
                        <tr>
                            <td>Title:</td>
                            <td><%= this.ArticleEntity.Title %></td>
                        </tr>
                        <tr>
                            <td>Author:</td>
                            <td><a href="<%: FriendlyUrl.Href("~/Author", this.ArticleEntity.Author.Name) %>"><%= this.ArticleEntity.Author.Name %></a></td>
                        </tr>
                        <tr>
                            <td>Publish Date:</td>
                            <td><%= this.ArticleEntity.PublishDate.ToShortDateString() %></td>
                        </tr>
                        <tr>
                            <td>Store Date:</td>
                            <td><%= this.ArticleEntity.StoreDate.ToShortDateString() %></td>
                        </tr>
                        <tr>
                            <td>Review:</td>
                            <td><%= this.ArticleEntity.Review %></td>
                        </tr>
                    </tbody>
                </table>

                <div class="pull-right">
                    <button class="btn btn-primary" runat="server" id="btnPurchaseButton" onserverclick="btnPurchaseButton_ServerClick">Purchase</button>
                </div>

                <div runat="server" ID="ltrPaymentNotice" class="well">
                    <h3>Payment Information</h3>

                    <p>
                        Your process is taken, you should make your payment to our bank account which is specified below:<br />
                        <br />
                        TC Garanti Bankasi<br />
                        iGaranti Subesi<br />
                        <br />
                        IBAN: TR00 0000 0000 0000 0000-00
                    </p>

                    <div class="pull-right">
                        <button class="btn btn-primary" runat="server" id="btnCancelButton" onserverclick="btnCancelButton_ServerClick">Cancel</button>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div runat="server" ID="ltrContent">
                    <h3>Content</h3>

                    <p><%= this.ArticleEntity.Content %></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
