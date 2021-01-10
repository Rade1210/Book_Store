using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class ShoppingCartsRepository
    {
        string connectionString = GlobalVariables.connectionString;

        public List<ShoppingCart> GetAllShoppingCarts()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM SHOPPING_CARTS";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<ShoppingCart> listToReturn = new List<ShoppingCart>();

                while (sqlDataReader.Read())
                {
                    int id = sqlDataReader.GetInt32(0);
                    int client = sqlDataReader.GetInt32(1);
                    string status = sqlDataReader.GetString(2);

                    ShoppingCart shoppingCart = new ShoppingCart(id, client, status);

                    listToReturn.Add(shoppingCart);
                }

                return listToReturn;
            }
        }

        public int InsertShoppingCart(ShoppingCart shoppingCart)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format(
                    "INSERT INTO SHOPPING_CARTS VALUES ({0}, '{1}')", shoppingCart.Client, shoppingCart.Status);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public ShoppingCart GetActiveShoppingCart(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM SHOPPING_CARTS WHERE client = " + id + " AND status = 'ACTIVE'";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                ShoppingCart shoppingCart = null;

                if (sqlDataReader.Read())
                {
                    int SCid = sqlDataReader.GetInt32(0);
                    int client = sqlDataReader.GetInt32(1);
                    string status = sqlDataReader.GetString(2);

                    shoppingCart = new ShoppingCart(SCid, client, status);
                }

                return shoppingCart;
            }
        }

        public int UpdateShoppingCart(ShoppingCart shoppingCart)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE SHOPPING_CARTS SET client = {0}, status = '{1}' WHERE id = {2}", shoppingCart.Client, shoppingCart.Status, shoppingCart.Id);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteShoppingCart(int shoppingCartId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM SHOPPING_CARTS WHERE id = {0}", shoppingCartId);

                return sqlCommand.ExecuteNonQuery();
            }

        }
    }
}

