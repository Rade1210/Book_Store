using DatabaseLayer;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ShoppingCartItemsBusiness
    {
        private ShoppingCartItemsRepository shoppingCartItemsRepository;
        public ShoppingCartItemsBusiness()
        {
            this.shoppingCartItemsRepository = new ShoppingCartItemsRepository();
        }
        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            return this.shoppingCartItemsRepository.GetAllShoppingCartItems();
        }
        public List<ShoppingCartItemForList> itemsForList(int id)
        {
            return this.shoppingCartItemsRepository.itemsForList(id);
        }
        public string InsertShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItemsRepository.InsertShoppingCartItem(shoppingCartItem) != 0)
                return "Shopping cart item successfully inserted into the database!";
            else
                return "Shopping cart item was not inserted into the database!";
        }
        public string DeleteShoppingCartItem(int id)
        {
            if (shoppingCartItemsRepository.DeleteShoppingCartItem(id) != 0)
                return "Shopping cart item successfully deleted!";
            else
                return "Shopping cart item was not deleted!";
        }
        public string UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            if (shoppingCartItemsRepository.UpdateShoppingCartItem(shoppingCartItem) != 0)
                return "Shopping cart item successfully updated!";
            else
                return "Shopping cart item was not updated!";
        }
    }
}
