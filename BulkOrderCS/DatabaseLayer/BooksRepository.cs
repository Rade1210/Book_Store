using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class BooksRepository
    {
        string connectionString = GlobalVariables.connectionString;

        public List<Book> GetAllBooks()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM BOOKS";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<Book> listToReturn = new List<Book>();

                while (sqlDataReader.Read())
                {
                    int isbn = sqlDataReader.GetInt32(0);
                    string title = sqlDataReader.GetString(1);
                    string author = sqlDataReader.GetString(2);
                    string description = sqlDataReader.GetString(3);
                    double price = sqlDataReader.GetDouble(4);
                    string category = sqlDataReader.GetString(5);
                    string cover = sqlDataReader.GetString(6);
                    string image = sqlDataReader.GetString(7);
                    int quantity = sqlDataReader.GetInt32(8);

                    Book book = new Book(isbn, title, author, description, price, category, cover, image, quantity);

                    listToReturn.Add(book);
                }

                return listToReturn;
            }
        }

        public int InsertBook(Book book)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format(
                    "INSERT INTO BOOKS VALUES ({0}, '{1}', '{2}', '{3}', {4}, '{5}', '{6}', '{7}', {8})", book.Isbn, book.Title, book.Author, book.Description, book.Price, book.Category, book.Cover, book.Image, book.Quantity);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int UpdateBook(Book book)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("UPDATE BOOKS SET title = '{0}', author = '{1}', description = '{2}', price = {3}, category = '{4}', cover = '{5}', image = '{6}', quantity = '{7}' WHERE isbn = {8}", book.Title, book.Author, book.Description, book.Price, book.Category, book.Cover, book.Image, book.Quantity, book.Isbn);
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public int DeleteBook(int isbn)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = string.Format("DELETE FROM BOOKS WHERE isbn = {0}", isbn);

                return sqlCommand.ExecuteNonQuery();
            }

        }

        public List<string[]> GetAllCategories()
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT category, COUNT(isbn) FROM BOOKS GROUP BY category";

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                List<string[]> listToReturn = new List<string[]>();

                while (sqlDataReader.Read())
                {
                    string category = sqlDataReader.GetString(0);
                    string count = sqlDataReader.GetInt32(1).ToString();

                    listToReturn.Add(new string[] { category, count });
                }

                return listToReturn;
            }
        }
    }
}
