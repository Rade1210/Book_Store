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
    public partial class Cart : System.Web.UI.Page
    {
        private ShoppingCartItemsBusiness shoppingCartItemsBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            shoppingCartItemsBusiness = new ShoppingCartItemsBusiness();

            if (ShoppingCartsBusiness.getSetCurrentShoppingCart == null)
            {
                Response.Redirect("/Login.aspx");
            }

            fillTable();

            if (Request.QueryString["changeQuantity"] != null && Request.QueryString["isbn"] != null
                && Request.QueryString["quantity"] != null)
            {
                int changeId = Int32.Parse(Request.QueryString["changeQuantity"]);
                int isbn = Int32.Parse(Request.QueryString["isbn"]);
                int quantity = Int32.Parse(Request.QueryString["quantity"]);

                ChangeQuantity(changeId, isbn, quantity);

            }

            if (Request.QueryString["deleteId"] != null)
            {
                int deleteId = Int32.Parse(Request.QueryString["deleteId"]);
                RemoveBook(deleteId);
            }
        }

        protected void RemoveBook(int id)
        {
            shoppingCartItemsBusiness.DeleteShoppingCartItem(id);

            Response.Redirect("Cart");
        }

        protected void ChangeQuantity(int id, int isbn, int quantity)
        {
            int shoppingCart = ShoppingCartsBusiness.getSetCurrentShoppingCart.Id;
            ShoppingCartItem change = new ShoppingCartItem(id, quantity, shoppingCart, isbn);

            shoppingCartItemsBusiness.UpdateShoppingCartItem(change);

            Response.Redirect("Index");
        }

        protected void fillTable()
        {
            string scheme =
                @"
                <tr>
                    <td class=""col-sm-8 col-md-6"">
                        <div class=""media"">
                            <img src = ""src/img/{0}"" style=""width: 72px; height: 95px;"">
                            <div class=""ml-3"">
                                <h4>Title: {1}</h4>
                                <h5>Author: {2}</h5>
                                <span>Status: </span><span class=""text-success""><strong>In Stock</strong></span>
                            </div>
                        </div>
                    </td>
                    <td class=""col-sm-1"" style=""text-align: center"">
                        <input type = ""text"" class=""form-control inp1"" value=""{3}"">
                    </td>
                    <td class=""col-sm-1 text-center""><strong>{4} USD</strong></td>
                    <td class=""col-sm-1 text-center""><strong>{5} USD</strong></td>
                    <td class=""col-sm-1 pl-5"">
                        <a id = ""removeBook"" href=""Cart.aspx?deleteId={6}"" style=""width:7rem"" class=""btn btn-danger"">
                                    Remove
                        </a>
                     </td>
                </tr>
                ";
            List<ShoppingCartItemForList> list = shoppingCartItemsBusiness.itemsForList(ShoppingCartsBusiness.getSetCurrentShoppingCart.Id);

            double price = 0;

            for (int i = 0; i < list.Count; i++)
            {
                price += list[i].Price * list[i].Quantity;
                table.InnerHtml += string.Format(scheme, list[i].Cover, list[i].Title, list[i].Author, list[i].Quantity, list[i].Price, (double)(list[i].Price * list[i].Quantity), list[i].ItemId, list[i].Isbn);
            }

            table.InnerHtml += string.Format(@"<tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <h5>Subtotal</h5>
                            </td>
                            <td class=""text-right"">
                                  <h5><strong>{0}</strong></h5>
                              </td>
                          </tr>
                           <tr>
                              <td></td>
                              <td></td>
                              <td></td>
                              <td>
                                  <h5>Shipping</h5>
                              </td>
                              <td class=""text-right"">
                                <h5><strong>{1}</strong></h5>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <h3>Total</h3>
                            </td>
                            <td class=""text-right"">
                                <h3><strong>{2}</strong></h3>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td></td>
                            <td>
                                <p id=""purchase"" runat=""server"" class=""btn btn-primary purchase"" onserverclick=""purchase_ServerClick"" data-toggle=""modal"" data-target=""#exampleModal"">Purchase</p>
                            </td>
                        </tr>", price, (double)(price / 10), price + (price / 10));
        }

        protected void purchase_ServerClick(object sender, EventArgs e)
        {
            ShoppingCartsBusiness.getSetCurrentShoppingCart.Status = "Purchased";
            new ShoppingCartsBusiness().UpdateShoppingCart(ShoppingCartsBusiness.getSetCurrentShoppingCart);
            ShoppingCartsBusiness.getSetCurrentShoppingCart = null;
        }
    }
}