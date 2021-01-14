using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BulkOrderCS
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientsBusiness.getSetCurrentClient = null;
            ShoppingCartsBusiness.getSetCurrentShoppingCart = null;
            Response.Redirect("Index");
        }
    }
}