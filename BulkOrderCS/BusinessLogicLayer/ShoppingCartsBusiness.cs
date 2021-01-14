using DatabaseLayer;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ShoppingCartsBusiness
    {
        private static ShoppingCart currentShoppingCart;

        public static ShoppingCart getSetCurrentShoppingCart
        {
            get { return currentShoppingCart; }
            set { currentShoppingCart = value; }
        }

        private ShoppingCartsRepository shoppingCartsRepository;
        public ShoppingCartsBusiness()
        {
            this.shoppingCartsRepository = new ShoppingCartsRepository();
        }
        public List<ShoppingCart> GetAllShoppingCarts()
        {
            return this.shoppingCartsRepository.GetAllShoppingCarts();
        }
        public string InsertShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCartsRepository.InsertShoppingCart(shoppingCart) != 0)
                return "Shopping cart successfully inserted into the database!";
            else
                return "Shopping cart was not inserted into the database!";
        }
        public string DeleteShoppingCart(int id)
        {
            if (shoppingCartsRepository.DeleteShoppingCart(id) != 0)
                return "Shopping cart successfully deleted!";
            else
                return "Shopping cart was not deleted!";
        }
        public string UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            if (shoppingCartsRepository.UpdateShoppingCart(shoppingCart) != 0)
                return "Shopping cart successfully updated!";
            else
                return "Shopping cart was not updated!";
        }
        public void initShoppingCart(int id)
        {
            if (getSetCurrentShoppingCart == null)
            {
                getSetCurrentShoppingCart = shoppingCartsRepository.GetActiveShoppingCart(id);
                if (getSetCurrentShoppingCart == null)
                {
                    ShoppingCart shoppingCart = new ShoppingCart(0, id, "Active");
                    shoppingCartsRepository.InsertShoppingCart(shoppingCart);
                    getSetCurrentShoppingCart = shoppingCart;
                }
            }
        }
    }
}