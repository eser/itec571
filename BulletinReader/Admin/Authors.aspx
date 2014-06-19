<%@ Page Title="Authors" Language="C#" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="BulletinReader.Admin.Authors" MasterPageFile="~/Layout.Master" Async="true" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>
<%@ Import Namespace="BulletinReader.DataClasses" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Authors <small>Add new or modify existing authors</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <asp:ValidationSummary runat="server" HeaderText="There were errors on the page:" CssClass="alert alert-warning" />

        <div class="form-group">
            <label for="Author">Author</label>
            <asp:DropDownList ID="Author" runat="server" ClientIDMode="Static" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="Author_SelectedIndexChanged"></asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="Name">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Name" ErrorMessage="Full name is required.">* </asp:RequiredFieldValidator>
                Full name:
            </label>
            <asp:TextBox ID="Name" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="Birthdate">
                <asp:CompareValidator runat="server" Type="Date" Operator="DataTypeCheck" ControlToValidate="Birthdate" ErrorMessage="Please enter a valid date.">* </asp:CompareValidator>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Birthdate" ErrorMessage="Please enter a date.">* </asp:RequiredFieldValidator>
                Birthdate
            </label>
            <asp:TextBox ID="Birthdate" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>

        <asp:Button ID="UpdateButton" runat="server" Text="Update" CssClass="btn btn-primary" OnClick="UpdateButton_Click" />
    </div>
</asp:Content>
