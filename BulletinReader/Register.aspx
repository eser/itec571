<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BulletinReader.Register" MasterPageFile="~/Layout.Master" Async="true" %>

<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Register</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Register <small>Create a new user account</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <asp:ValidationSummary runat="server" HeaderText="There were errors on the page:" CssClass="alert alert-warning" />

        <div class="form-group">
            <label for="txtFullname">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFullname" ErrorMessage="Full name is required.">* </asp:RequiredFieldValidator>
                Full name
            </label>
            <asp:TextBox ID="txtFullname" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtUsername">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtUsername" ErrorMessage="Username is required.">* </asp:RequiredFieldValidator>
                Username
            </label>
            <asp:TextBox ID="txtUsername" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
        </div>
        
        <div class="form-group">
            <label for="txtEmail">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail is required.">* </asp:RequiredFieldValidator>
                E-mail
            </label>
            <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPassword">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPassword" ErrorMessage="Password is required.">* </asp:RequiredFieldValidator>
                Password
            </label>
            <asp:TextBox ID="txtPassword" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPasswordR">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPasswordR" ErrorMessage="Repeatation of password is required.">* </asp:RequiredFieldValidator>
                <asp:CompareValidator runat="server" ControlToValidate="txtPasswordR" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match.">* </asp:CompareValidator>
                Re-enter Password
            </label>
            <asp:TextBox ID="txtPasswordR" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPhoneNumber">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtPhoneNumber" ErrorMessage="Phone Number is required.">* </asp:RequiredFieldValidator>
                Phone Number
            </label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Phone"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtAddress">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtAddress" ErrorMessage="Address is required.">* </asp:RequiredFieldValidator>
                Address
            </label>
            <asp:TextBox ID="txtAddress" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
        </div>

        <asp:Button ID="btnSubmitButton" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmitButton_Click" />
    </div>
</asp:Content>
