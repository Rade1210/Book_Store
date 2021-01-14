using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BulkOrderCS
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl login = new HtmlGenericControl("a");
            login.Attributes.Add("class", "nav-link");
            if (ClientsBusiness.getSetCurrentClient == null)
            {
                login.Attributes.Add("href", "/Login");
                login.InnerText = "Login";
            } else
            {
                login.Attributes.Add("href", "/Logout");
                login.InnerText = "Logout";
            }
            loginIf.Controls.Add(login);
        }
    }
}