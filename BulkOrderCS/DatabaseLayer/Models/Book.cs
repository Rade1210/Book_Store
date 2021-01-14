using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class Book
    {
        public Book(int isbn, string title, string author, string description, double price, string category, string cover, string image, int quantity)
        {
            this.Isbn = isbn;
            this.Title = title;
            this.Author = author;
            this.Description = description;
            this.Price = price;
            this.Category = category;
            this.Cover = cover;
            this.Image = image;
            this.Quantity = quantity;
        }

        private int isbn;
        private string title;
        private string author;
        private string description;
        private double price;
        private string category;
        private string cover;
        private string image;
        private int quantity;

        public int Isbn { get => isbn; set => isbn = value; }
        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Description { get => description; set => description = value; }
        public double Price { get => price; set => price = value; }
        public string Category { get => category; set => category = value; }
        public string Cover { get => cover; set => cover = value; }
        public string Image { get => image; set => image = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
