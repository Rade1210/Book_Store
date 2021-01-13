<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BulkOrderCS.Index" %>

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

     <div id="demo" class="container carousel slide" data-ride="carousel">

  <!-- Indicators -->
  <ul class="carousel-indicators">
    <li data-target="#demo" data-slide-to="0" class="active"></li>
    <li data-target="#demo" data-slide-to="1"></li>
    <li data-target="#demo" data-slide-to="2"></li>
  </ul>
  <br />
  <!-- The slideshow -->
  <div class="carousel-inner">
    <div class="carousel-item active">
      <img src="https://i.imgur.com/us7tcBW.jpg" alt="a lot of books" width="1100" height="500">
    </div>
    <div class="carousel-item">
      <img src="https://i.imgur.com/NqePdVC.jpg" alt="a bunch of books" width="1100" height="500">
    </div>
    <div class="carousel-item">
      <img src="https://i.imgur.com/YMdfjiY.jpg" alt="a couple of books" width="1100" height="500">
    </div>
  </div>
  
  <!-- Left and right controls -->
  <a class="carousel-control-prev" href="#demo" data-slide="prev">
    <span class="carousel-control-prev-icon"></span>
  </a>
  <a class="carousel-control-next" href="#demo" data-slide="next">
    <span class="carousel-control-next-icon"></span>
  </a>
</div>

    <div class="container pb-5 pt-5">
        <div class="row mb-5 pb-3 justify-content-around" runat="server" id="bookCardRow">
        </div>
    </div>
</asp:Content>
