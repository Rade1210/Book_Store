<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DatabaseTestForm.aspx.cs" Inherits="BulkOrderCS.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h3>Client</h3>
        <div class="d-flex justify-content-around">
            <asp:Button ID="ButtonClientSelect" CssClass="btn btn-primary w-25" runat="server" Text="Select" OnClick="clientSelect" />
            <asp:Button ID="ButtonClientInsert" CssClass="btn btn-secondary w-25" runat="server" Text="Insert" OnClick="clientInsert" />
            <asp:Button ID="ButtonClientUpdate" CssClass="btn btn-warning w-25" runat="server" Text="Update" OnClick="clientUpdate" />
            <asp:Button ID="ButtonClientDelete" CssClass="btn btn-danger w-25" runat="server" Text="Delete" OnClick="clientDelete" />
        </div>
        <h3>ShoppingCart</h3>
        <div class="d-flex justify-content-around">
            <asp:Button ID="ButtonShoppingCartSelect" CssClass="btn btn-primary w-25" runat="server" Text="Select" OnClick="shoppingCartSelect" />
            <asp:Button ID="ButtonShoppingCartInsert" CssClass="btn btn-secondary w-25" runat="server" Text="Insert" OnClick="shoppingCartInsert" />
            <asp:Button ID="ButtonShoppingCartUpdate" CssClass="btn btn-warning w-25" runat="server" Text="Update" OnClick="shoppingCartUpdate" />
            <asp:Button ID="ButtonShoppingCartDelete" CssClass="btn btn-danger w-25" runat="server" Text="Delete" OnClick="shoppingCartDelete" />
        </div>
        <h3>ShoppingCartItem</h3>
        <div class="d-flex justify-content-around">
            <asp:Button ID="ButtonShoppingCartItemSelect" CssClass="btn btn-primary w-25" runat="server" Text="Select" OnClick="shoppingCartItemSelect" />
            <asp:Button ID="ButtonShoppingCartItemInsert" CssClass="btn btn-secondary w-25" runat="server" Text="Insert" OnClick="shoppingCartItemInsert" />
            <asp:Button ID="ButtonShoppingCartItemUpdate" CssClass="btn btn-warning w-25" runat="server" Text="Update" OnClick="shoppingCartItemUpdate" />
            <asp:Button ID="ButtonShoppingCartItemDelete" CssClass="btn btn-danger w-25" runat="server" Text="Delete" OnClick="shoppingCartItemDelete" />
        </div>
        <h3>Book</h3>
        <div class="d-flex justify-content-around">
            <asp:Button ID="ButtonBookSelect" CssClass="btn btn-primary w-25" runat="server" Text="Select" OnClick="bookSelect" />
            <asp:Button ID="ButtonBookInsert" CssClass="btn btn-secondary w-25" runat="server" Text="Insert" OnClick="bookInsert" />
            <asp:Button ID="ButtonBookUpdate" CssClass="btn btn-warning w-25" runat="server" Text="Update" OnClick="bookUpdate" />
            <asp:Button ID="ButtonBookDelete" CssClass="btn btn-danger w-25" runat="server" Text="Delete" OnClick="bookDelete" />
        </div>
        <div class="d-flex justify-content-around">
            <asp:TextBox ID="TextBoxSelect" CssClass="w-25 h-75" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxInsert" CssClass="w-25 h-75" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxUpdate" CssClass="w-25 h-75" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBoxDelete" CssClass="w-25 h-75" runat="server"></asp:TextBox>
        </div>
    <hr />
    </div>

</asp:Content>
