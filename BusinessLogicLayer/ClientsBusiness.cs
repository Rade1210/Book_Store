using DatabaseLayer;
using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ClientsBusiness
    {
        private static Client currentClient;

        public static Client getSetCurrentClient
        {
            get { return currentClient; }
            set { currentClient = value; }
        }

        private ClientsRepository clientsRepository;

        public ClientsBusiness()
        {
            this.clientsRepository = new ClientsRepository();
        }
        public List<Client> GetAllClients()
        {
            return this.clientsRepository.GetAllClients();
        }
        public string InsertClient(Client client)
        {
            if (clientsRepository.InsertClient(client) != 0)
                return "Client successfully inserted into the database!";
            else
                return "Client was not inserted into the database!";
        }
        public string DeleteClient(int id)
        {
            if (clientsRepository.DeleteClient(id) != 0)
                return "Client successfully deleted!";
            else
                return "Client was not deleted!";
        }
        public string UpdateClient(Client client)
        {
            if (clientsRepository.UpdateClient(client) != 0)
                return "Client successfully updated!";
            else
                return "Client was not updated!";
        }
    }
}
