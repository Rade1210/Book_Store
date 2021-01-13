<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="BulkOrderCS.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="adminTitle">Book title</label>
                <input type="text" class="form-control" id="adminTitle" runat="server" required>
            </div>
            <div class="form-group col-md-6">
                <label for="adminAuthor">Author</label>
                <input type="text" class="form-control" id="adminAuthor" runat="server" required>
            </div>
        </div>
        <div class="form-group">
            <label for="adminDescription">Description</label>
            <textarea class="form-control" id="adminDescription" runat="server" required></textarea>
        </div>
        <div class="form-row">
            <div class="form-group col-md-4">
                <label for="adminCategory">Category</label>
                <input type="text" class="form-control" id="adminCategory" runat="server" required>
            </div>
            <div class="form-group col-md-4">
                <label for="adminPrice">Price</label>
                <input type="text" class="form-control" id="adminPrice" runat="server" required>
            </div>
            <div class="form-group col-md-4">
                <label for="adminQuantity">Quantity</label>
                <input type="text" class="form-control" id="adminQuantity" runat="server" required>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="adminCover">Cover</label>
                <input type="text" class="form-control" id="adminCover" runat="server" required>
            </div>
            <div class="form-group col-md-6">
                <label for="adminImage">Image</label>
                <input type="text" class="form-control" id="adminImage" runat="server" required>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-6">
                <label for="adminIsbn">ISBN</label>
                <input type="text" class="form-control" id="adminIsbn" runat="server" required>
            </div>
            <div class="form-group col-md-6 pt-5">
                <button class="btn btn-primary float-right" runat="server" id="btnAdminInsertBook" onserverclick="btnAdminInsertBook_ServerClick">Upload</button>
            </div>
        </div>
    </div>
</asp:Content>
