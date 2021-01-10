using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem(int id, int quantity, int shoppingCart, int isbn)
        {
            this.Id = id;
            this.Quantity = quantity;
            this.shoppingCart = shoppingCart;
            this.Isbn = isbn;
        }

        private int id;
        private int quantity;
        private int shoppingCart;
        private int isbn;

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int ShoppingCart { get => shoppingCart; set => shoppingCart = value; }
        public int Isbn { get => isbn; set => isbn = value; }
    }
}
