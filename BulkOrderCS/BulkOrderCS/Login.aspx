<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BulkOrderCS.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="d-flex justify-content-center align-items-center" style="height: 75vh">
            <div class="card w-50">
                <div class="card-body text-center">
                    <img class="mb-4" src="/src/img/login.png" alt="" width="72" height="72">

                    <h1 class="h3 mb-3 font-weight-normal">Please sign in</h1>

                    <label for="inputUsername" class="sr-only">Email address</label>
                    <input type="text" id="inputUsername" class="form-control my-2" placeholder="Username" required="" runat="server">
                    <label for="inputPassword" class="sr-only">Password</label>
                    <input type="password" id="inputPassword" class="form-control my-2" placeholder="Password" required="" runat="server">

                    <button id="btnLogin" onserverclick="btnLogin_ServerClick" class="btn btn-primary btn-block my-2" type="button" runat="server">Log in</button>

                    <p id="incorrect" class="text-danger" hidden runat="server">Incorrect username or password, please try again or go <a href="Index.aspx">back</a></p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
