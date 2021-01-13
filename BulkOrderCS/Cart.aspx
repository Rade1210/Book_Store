<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="BulkOrderCS.Cart" %>

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
    <div class="container">
        <div class="row mt-3">
            <div class="col-12">
                <table class="table table-hover">
                    <thead>
                        <tr>
                            <th>Product</th>
                            <th>Quantity</th>
                            <th class="text-center">Price</th>
                            <th class="text-center">Total</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody id="table" runat="server">
                        
                        
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    
</asp:Content>
