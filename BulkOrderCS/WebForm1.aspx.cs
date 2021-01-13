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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private ClientsBusiness clientsBusiness;
        private ShoppingCartsBusiness shoppingCartsBusiness;
        private ShoppingCartItemsBusiness shoppingCartItemsBusiness;
        private BooksBusiness booksBusiness;
        protected void Page_Load(object sender, EventArgs e)
        {
            clientsBusiness = new ClientsBusiness();
            shoppingCartsBusiness = new ShoppingCartsBusiness();
            shoppingCartItemsBusiness = new ShoppingCartItemsBusiness();
            booksBusiness = new BooksBusiness();

            TextBoxSelect.TextMode = TextBoxMode.MultiLine;
            TextBoxInsert.TextMode = TextBoxMode.MultiLine;
            TextBoxUpdate.TextMode = TextBoxMode.MultiLine;
            TextBoxDelete.TextMode = TextBoxMode.MultiLine;
        }

        protected void clientSelect(object sender, EventArgs e)
        {
            ButtonClientSelect.Text = "Clicked";

            string allClients = "";

            foreach(Client client in clientsBusiness.GetAllClients())
            {
                allClients += client.Id + " " + client.Name + "\n";
            }

            TextBoxSelect.Text = allClients;
        }
        protected void clientInsert(object sender, EventArgs e)
        {
            ButtonClientInsert.Text = "Clicked";

            Client client = new Client(0, "Evan", "Eager", "EEAddress", "DDCity", "0123456789", "EE@email.com", "EEUsername", "EEPassword");

            TextBoxInsert.Text = clientsBusiness.InsertClient(client);
        }
        protected void clientUpdate(object sender, EventArgs e)
        {
            ButtonClientUpdate.Text = "Clicked";

            int id = Int32.Parse(TextBoxUpdate.Text);

            Client client = new Client(id, "Fvan", "Eager", "EEAddress", "DDCity", "0123456789", "EE@email.com", "EEUsername", "EEPassword");

            TextBoxUpdate.Text = clientsBusiness.UpdateClient(client);
        }
        protected void clientDelete(object sender, EventArgs e)
        {
            ButtonClientDelete.Text = "Clicked";

            int id = Int32.Parse(TextBoxDelete.Text);

            TextBoxDelete.Text = clientsBusiness.DeleteClient(id);
        }

        protected void shoppingCartSelect(object sender, EventArgs e)
        {
            ButtonShoppingCartSelect.Text = "Clicked";

            string allShoppingCarts = "";

            foreach (ShoppingCart shoppingCart in shoppingCartsBusiness.GetAllShoppingCarts())
            {
                allShoppingCarts += shoppingCart.Id + " " + shoppingCart.Status + "\n";
            }

            TextBoxSelect.Text = allShoppingCarts;
        }
        protected void shoppingCartInsert(object sender, EventArgs e)
        {
            ButtonShoppingCartInsert.Text = "Clicked";

            ShoppingCart shoppingCart = new ShoppingCart(0, 1, "Active");

            TextBoxInsert.Text = shoppingCartsBusiness.InsertShoppingCart(shoppingCart);
        }
        protected void shoppingCartUpdate(object sender, EventArgs e)
        {
            ButtonShoppingCartUpdate.Text = "Clicked";

            int id = Int32.Parse(TextBoxUpdate.Text);

            ShoppingCart shoppingCart = new ShoppingCart(id, 1, "Deleted");

            TextBoxUpdate.Text = shoppingCartsBusiness.UpdateShoppingCart(shoppingCart);
        }
        protected void shoppingCartDelete(object sender, EventArgs e)
        {
            ButtonShoppingCartDelete.Text = "Clicked";

            int id = Int32.Parse(TextBoxDelete.Text);

            TextBoxDelete.Text = shoppingCartsBusiness.DeleteShoppingCart(id);
        }

         protected void shoppingCartItemSelect(object sender, EventArgs e)
        {
            ButtonShoppingCartItemSelect.Text = "Clicked";

            string allShoppingCartItems = "";

            foreach (ShoppingCartItem shoppingCartItem in shoppingCartItemsBusiness.GetAllShoppingCartItems())
            {
                allShoppingCartItems += shoppingCartItem.Id + " " + shoppingCartItem.Isbn + "\n";
            }

            TextBoxSelect.Text = allShoppingCartItems;
        }
        protected void shoppingCartItemInsert(object sender, EventArgs e)
        {
            ButtonShoppingCartItemInsert.Text = "Clicked";

            ShoppingCartItem shoppingCartItem = new ShoppingCartItem(0, 12, 1, 8821);

            TextBoxInsert.Text = shoppingCartItemsBusiness.InsertShoppingCartItem(shoppingCartItem);
        }
        protected void shoppingCartItemUpdate(object sender, EventArgs e)
        {
            ButtonShoppingCartItemUpdate.Text = "Clicked";

            int id = Int32.Parse(TextBoxUpdate.Text);

            ShoppingCartItem shoppingCartItem = new ShoppingCartItem(id, 15, 1, 8821);

            TextBoxUpdate.Text = shoppingCartItemsBusiness.UpdateShoppingCartItem(shoppingCartItem);
        }
        protected void shoppingCartItemDelete(object sender, EventArgs e)
        {
            ButtonShoppingCartItemDelete.Text = "Clicked";

            int id = Int32.Parse(TextBoxDelete.Text);

            TextBoxDelete.Text = shoppingCartItemsBusiness.DeleteShoppingCartItem(id);
        }
        
        protected void bookSelect(object sender, EventArgs e)
        {
            ButtonBookSelect.Text = "Clicked";

            string allBooks = "";

            foreach (Book book in booksBusiness.GetAllBooks())
            {
                allBooks += book.Isbn + " " + book.Title + "\n";
            }

            TextBoxSelect.Text = allBooks;
        }
        protected void bookInsert(object sender, EventArgs e)
        {
            ButtonBookInsert.Text = "Clicked";

            Book book = new Book(777, "TTitle", "Tauthor", "Tdescription", 123.45, "TCategory", "TUrlToCover", "TUrlToImage", 3);

            TextBoxInsert.Text = booksBusiness.InsertBook(book);
        }
        protected void bookUpdate(object sender, EventArgs e)
        {
            ButtonBookUpdate.Text = "Clicked";

            int id = Int32.Parse(TextBoxUpdate.Text);

            Book book = new Book(id, "TUpdTitle", "Tauthor", "Tdescription", 123.45, "TCategory", "TUrlToCover", "TUrlToImage", 3);

            TextBoxUpdate.Text = booksBusiness.UpdateBook(book);
        }
        protected void bookDelete(object sender, EventArgs e)
        {
            ButtonBookDelete.Text = "Clicked";

            int id = Int32.Parse(TextBoxDelete.Text);

            TextBoxDelete.Text = booksBusiness.DeleteBook(id);
        }
    }
}