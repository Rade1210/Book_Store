using BusinessLogicLayer;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BulkOrderCS
{
    public partial class Login : System.Web.UI.Page
    {
        private ClientsBusiness clientBusiness;
        private ShoppingCartsBusiness shoppingCartsBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            clientBusiness = new ClientsBusiness();
            shoppingCartsBusiness = new ShoppingCartsBusiness();
        }

        protected void btnLogin_ServerClick(object sender, EventArgs e)
        {
            string username = inputUsername.Value;
            string password = inputPassword.Value;

            foreach (Client client in clientBusiness.GetAllClients())
            {
                if (username.Equals(client.Username))
                {
                    if (password.Equals(client.Password))
                    {
                        ClientsBusiness.getSetCurrentClient = client;
                        shoppingCartsBusiness.initShoppingCart(client.Id);
                        Response.Redirect("/Index");
                    }
                }
            }

            incorrect.Attributes.Remove("hidden");
        }
    }
}