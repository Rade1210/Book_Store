<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="BulkOrderCS.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        input::-webkit-outer-spin-button,
        input::-webkit-inner-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        /* Firefox */
        input[type=number] {
            -moz-appearance: textfield;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row pt-3">
            <div class="col-md-1 col-4"></div>
            <div class="col-md-2 col-4 pt-2">
                <div class="card">
                    <div class="card-body" id="categoriesSidebar" runat="server">
                        
                    </div>
                </div>
            </div>
            <div class="col-md-9 col-12">
                <div class="row justify-content-around mb-5 pb-3" id="categoriesContent" runat="server"></div>
            </div>
        </div>
    </div>
</asp:Content>
