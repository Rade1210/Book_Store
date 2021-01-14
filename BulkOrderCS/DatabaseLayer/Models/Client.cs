using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class Client
    {
        public Client(int id, string name, string surname, string address, string city, string phone_number, string email, string username, string password)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.Address = address;
            this.City = city;
            this.Phone_number = phone_number;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        private int id;
        private string name;
        private string surname;
        private string address;
        private string city;
        private string phone_number;
        private string email;
        private string username;
        private string password;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string Phone_number { get => phone_number; set => phone_number = value; }
        public string Email { get => email; set => email = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
    }
}
