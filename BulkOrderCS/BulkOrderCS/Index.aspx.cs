using BusinessLogicLayer;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulkOrderCS
{
    public partial class Index : System.Web.UI.Page
    {
        private BooksBusiness booksBusiness;
        private ShoppingCartItemsBusiness shoppingCartItemsBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            booksBusiness = new BooksBusiness();
            shoppingCartItemsBusiness = new ShoppingCartItemsBusiness();

            string isbn = Request.QueryString["isbn"];
            string quantity = Request.QueryString["quantity"];

            if (isbn != null && quantity != null)
                addToCart(isbn, quantity);

            fillBookCardRow();
        }

        private void fillBookCardRow()
        {
            string bookCard = @"<div class=""col-lg-3 col-md-3 col-sm-6 my-2"">
                <div class=""card mx-auto"" style=""width: 16rem;"">
                    <div class=""card-header"">
                        <p class=""text-center mb-0 pb-0 mx-5"" style=""background-color: #FFFF00"">{0}</p>
                    </div>
                    <img class=""card-img-top img-fluid mh-100"" style=""height: 270px"" src=""/src/img/{1}"" alt=""Card image cap"">
                    <div class=""card-body pb-0 mb-0 pt-1 mt-1"">
                        <h5 class=""card-title text-info"">{2}</h5>
                        <p class=""card-text"">{3}</p>
                        <p class=""text-muted text-right"">by: {4}</p>
                    </div>
                    <div class=""card-footer pt-1 mt-1"">
                        <div class=""row"">
                            <div class=""col-6"">
                                <p class=""text-muted mb-0"">Price:</p>
                                <p class=""text-muted mb-0 text-right"">{5}</p>
                            </div>
                            <div class=""col-6"">
                                <p class=""text-muted mb-0"">Quantity:</p>
                                <p class=""text-muted mb-0 text-right"">{6}</p>
                            </div>
                        </div>
                        <div class=""row mt-2 px-2"" style=""height: 2rem"">
                            <input id=""{7}"" class=""col-7 form-control inp"" type=""number"" min=""1"" max=""{6}""/>
                            <div class=""col-1 m-0 p-0""></div>
                            <a href=""#"" class=""btn btn-success col-4 but"">Buy</a>
                        </div>
                    </div>
                </div>
            </div>";

            foreach (Book book in booksBusiness.GetAllBooks())
            {
                bookCardRow.InnerHtml += string.Format(bookCard, book.Category, book.Cover, book.Title, book.Description, book.Author, book.Price, book.Quantity, book.Isbn);
            }
        }

        protected void addToCart(string isbn, string quantity)
        {
            if(ClientsBusiness.getSetCurrentClient == null)
            {
                Response.Redirect("Login.aspx");
            }

            ShoppingCartItem shoppingCartItem = new ShoppingCartItem(0, Int32.Parse(quantity), ShoppingCartsBusiness.getSetCurrentShoppingCart.Id, Int32.Parse(isbn));

            shoppingCartItemsBusiness.InsertShoppingCartItem(shoppingCartItem);
        }
    }
}