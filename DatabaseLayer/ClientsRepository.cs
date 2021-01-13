using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class ClientsRepository
    {
        string connectionString = GlobalVariables.connectionString;

        public List<Client> GetAllClients()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM CLIENTS";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Client> listToReturn = new List<Client>();

                while (sqlDataReader.Read())
                {
                    int id = sqlDataReader.GetInt32(0);
                    string name = sqlDataReader.GetString(1);
                    string surname = sqlDataReader.GetString(2);
                    string address = sqlDataReader.GetString(3);
                    string city = sqlDataReader.GetString(4);
                    string phone_number = sqlDataReader.GetString(5);
                    string email = sqlDataReader.GetString(6);
                    string username = sqlDataReader.GetString(7);
                    string password = sqlDataReader.GetString(8);

                    Client client = new Client(id, name, surname, address, city, phone_number, email, username, password);

                    listToReturn.Add(client);
                }

                return listToReturn;
            }
        }

        public int InsertClient(Client client)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format(
                    "INSERT INTO CLIENTS VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", client.Name, client.Surname, client.Address, client.City, client.Phone_number, client.Email, client.Username, client.Password);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateClient(Client client)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE CLIENTS SET name = '{0}', surname = '{1}', address = '{2}', city = '{3}', phone_number = '{4}', email = '{5}', username = '{6}', password = '{7}' WHERE id = {8}", client.Name, client.Surname, client.Address, client.City, client.Phone_number, client.Email, client.Username, client.Password, client.Id); ;
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteClient(int clientId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM CLIENTS WHERE id = {0}", clientId);

                return sqlCommand.ExecuteNonQuery();
            }

        }
    }
}