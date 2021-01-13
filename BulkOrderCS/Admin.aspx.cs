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
    public partial class Admin : System.Web.UI.Page
    {
        BooksBusiness booksBusiness;

        protected void Page_Load(object sender, EventArgs e)
        {
            booksBusiness = new BooksBusiness();
        }

        protected void btnAdminInsertBook_ServerClick(object sender, EventArgs e)
        {
            int isbn = Int32.Parse(adminIsbn.Value);
            string title = adminTitle.Value;
            string author = adminAuthor.Value;
            string description = adminDescription.Value;
            double price = Double.Parse(adminPrice.Value);
            string category = adminCategory.Value;
            string cover = adminCover.Value;
            string image = adminImage.Value;
            int quantity = Int32.Parse(adminQuantity.Value);

            Book book = new Book(isbn, title, author, description, price, category, cover, image, quantity);

            booksBusiness.InsertBook(book);
            Response.Redirect("Index");
        }
    }
}