using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class ShoppingCartItemsRepository
    {
        string connectionString = GlobalVariables.connectionString;

        public List<ShoppingCartItem> GetAllShoppingCartItems()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM SHOPPING_CART_ITEMS";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<ShoppingCartItem> listToReturn = new List<ShoppingCartItem>();

                while (sqlDataReader.Read())
                {
                    int id = sqlDataReader.GetInt32(0);
                    int quantity = sqlDataReader.GetInt32(1);
                    int shoppingCart = sqlDataReader.GetInt32(0);
                    int isbn = sqlDataReader.GetInt32(1);

                    ShoppingCartItem shoppingCartItem = new ShoppingCartItem(id, quantity, shoppingCart, isbn);

                    listToReturn.Add(shoppingCartItem);
                }

                return listToReturn;
            }
        }

        public int InsertShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format(
                    "INSERT INTO SHOPPING_CART_ITEMS VALUES ({0}, {1}, {2})", shoppingCartItem.Quantity, shoppingCartItem.ShoppingCart, shoppingCartItem.Isbn);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE SHOPPING_CART_ITEMS SET quantity = {0}, shopping_cart = {1}, isbn = {2} WHERE id = {3}", shoppingCartItem.Quantity, shoppingCartItem.ShoppingCart, shoppingCartItem.Isbn, shoppingCartItem.Id);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteShoppingCartItem(int shoppingCartItemId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM SHOPPING_CART_ITEMS WHERE id = {0}", shoppingCartItemId);

                return sqlCommand.ExecuteNonQuery();
            }
        }

        public List<ShoppingCartItemForList> itemsForList(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                // {0} - cover; {1} - title; {2} - author; {3} -  i; {4} - quantity; {5} - price; {6} - price * quantity; {7} - item id; {8} - isbn
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = @"select b.cover, b.title, b.author, sci.quantity, b.price, sci.id, b.isbn
                    from BOOKS b INNER JOIN SHOPPING_CART_ITEMS sci ON b.isbn = sci.isbn
                    where sci.shopping_cart = " + id;

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<ShoppingCartItemForList> listToReturn = new List<ShoppingCartItemForList>();

                while (sqlDataReader.Read())
                {
                    string cover = sqlDataReader.GetString(0);
                    string title = sqlDataReader.GetString(1);
                    string author = sqlDataReader.GetString(2);
                    int quantity = sqlDataReader.GetInt32(3);
                    double price = sqlDataReader.GetDouble(4);
                    int iid = sqlDataReader.GetInt32(5);
                    int isbn = sqlDataReader.GetInt32(6);

                    ShoppingCartItemForList scifl = new ShoppingCartItemForList(cover, title, author, quantity, price, iid, isbn);

                    listToReturn.Add(scifl);
                }

                return listToReturn;
            }
        }
    }
}
