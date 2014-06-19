<%@ Page Title="Edit My Profile" Language="C#" AutoEventWireup="true" CodeBehind="EditProfile.aspx.cs" Inherits="BulletinReader.Users.EditProfile" MasterPageFile="~/Layout.Master" Async="true" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">
    <div class="container">
        <div class="page-header">
            <h1>Edit My Profile <small>Change the details of user account</small></h1>
        </div>

        <asp:Literal ID="NotificationArea" runat="server" />

        <asp:ValidationSummary runat="server" HeaderText="There were errors on the page:" CssClass="alert alert-warning" />

        <h3>Password</h3>

        <div class="form-group">
            <label for="txtCurrentPassword">
                Current Password
            </label>
            <asp:TextBox ID="txtCurrentPassword" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPassword">
                New Password
            </label>
            <asp:TextBox ID="txtPassword" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPasswordR">
                <asp:CompareValidator runat="server" ControlToValidate="txtPasswordR" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match.">* </asp:CompareValidator>
                Re-enter New Password
            </label>
            <asp:TextBox ID="txtPasswordR" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <h3>Details</h3>

        <div class="form-group">
            <label for="txtFullname">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtFullname" ErrorMessage="Full name is required.">* </asp:RequiredFieldValidator>
                Full name
            </label>
            <asp:TextBox ID="txtFullname" runat="server" ClientIDMode="Static" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtEmail">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="txtEmail" ErrorMessage="E-mail is required.">* </asp:RequiredFieldValidator>
                E-mail
            </label>
            <asp:TextBox ID="txtEmail" runat="server" ClientIDMode="Static" CssClass="form-control" TextMode="Email"></asp:TextBox>
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
