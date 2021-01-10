using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    // {0} - cover; {1} - title; {2} - author; {3} -  i; {4} - quantity; {5} - price; {6} - price * quantity; {7} - item id; {8} - isbn
    public class ShoppingCartItemForList
    {


        private string cover;
        private string title;
        private string author;
        private int quantity;
        private double price;
        private int itemId;
        private int isbn;

        public ShoppingCartItemForList(string cover, string title, string author, int quantity, double price, int itemId, int isbn)
        {
            this.cover = cover;
            this.title = title;
            this.author = author;
            this.quantity = quantity;
            this.price = price;
            this.itemId = itemId;
            this.isbn = isbn;
        }

        public string Cover { get => cover; set => cover = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public int ItemId { get => itemId; set => itemId = value; }
        public int Isbn { get => isbn; set => isbn = value; }
    }
}
