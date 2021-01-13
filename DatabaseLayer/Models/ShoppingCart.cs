using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Models
{
    public class ShoppingCart
    {
        public ShoppingCart(int id, int client, string status)
        {
            this.Id = id;
            this.Client = client;
            this.Status = status;
        }

        private int id;
        private int client;
        private string status;

        public int Id { get => id; set => id = value; }
        public int Client { get => client; set => client = value; }
        public string Status { get => status; set => status = value; }
    }
}
