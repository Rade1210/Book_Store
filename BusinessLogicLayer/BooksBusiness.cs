using DatabaseLayer;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BooksBusiness
    {
        private BooksRepository booksRepository;
        public BooksBusiness()
        {
            this.booksRepository = new BooksRepository();
        }
        public List<Book> GetAllBooks()
        {
            return this.booksRepository.GetAllBooks().OrderBy(b => b.Title).ToList();
        }
        public string InsertBook(Book book)
        {
            if (booksRepository.InsertBook(book) != 0)
                return "Book successfully inserted into the database!";
            else
                return "Book was not inserted into the database!";
        }
        public string DeleteBook(int isbn)
        {
            if (booksRepository.DeleteBook(isbn) != 0)
                return "Book successfully deleted!";
            else
                return "Book was not deleted!";
        }
        public string UpdateBook(Book book)
        {
            if (booksRepository.UpdateBook(book) != 0)
                return "Book successfully updated!";
            else
                return "Book was not updated!";
        }
        public List<string[]> GetAllCategories()
        {
            return booksRepository.GetAllCategories();
        }
    }
}
