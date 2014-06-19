<%@ Page Title="Edit Article" Language="C#" AutoEventWireup="true" CodeBehind="ArticlesEdit.aspx.cs" Inherits="BulletinReader.Admin.ArticlesEdit" MasterPageFile="~/Layout.Master" Async="true" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<%@ Import Namespace="BulletinReader.DataClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Edit Article <small>Adds a new article into system</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <asp:ValidationSummary runat="server" HeaderText="There were errors on the page:" CssClass="alert alert-warning" />

        <div class="form-group">
            <label for="Author">Author</label>
            <asp:DropDownList ID="Author" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="ArticleTitle">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ArticleTitle" ErrorMessage="Title is required.">* </asp:RequiredFieldValidator>
                Title:
            </label>
            <asp:TextBox ID="ArticleTitle" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="PublishDate">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="PublishDate" ErrorMessage="Publish Date is required.">* </asp:RequiredFieldValidator>
                PublishDate:
            </label>
            <asp:TextBox ID="PublishDate" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="Review">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Review" ErrorMessage="Review is required.">* </asp:RequiredFieldValidator>
                Review:
            </label>
            <asp:TextBox ID="Review" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="Content">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Content" ErrorMessage="Content is required.">* </asp:RequiredFieldValidator>
                Content:
            </label>
            <asp:TextBox ID="Content" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="MultiLine" Rows="10"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="CoverImage">
                Cover Image:
            </label>
            <asp:FileUpload ID="CoverImage" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:FileUpload>
        </div>

        <asp:Button ID="UpdateButton" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="UpdateButton_Click" />
    </div>
</asp:Content>
