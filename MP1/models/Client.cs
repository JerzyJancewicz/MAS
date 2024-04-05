using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP1.models
{
    public class Client
    {
        private static List<Client> _clients = new List<Client>();
        // Ekst. trwałości
        private int _id = 0;
        private static int nextId = 1;
        // atr. zlozony
        private Address address = new Address();
        // atr. opcjonalny
        private string Email = "";
        // atr. powtarzalny
        private List<string> PhoneNumbers = new List<string>();
        // atr klasowy
        private int NumbersOfClient = 0;
        // atr pochodny
        private string FullName = ""; 
        // mtd klasowa
        // przeciazenie/ przysloniecie
        public Client()
        {
            _id = nextId++;
            NumbersOfClient++;
            _clients.Add(this);
        }

        public static ReadOnlyCollection<Client> GetClients()
        {
            return new ReadOnlyCollection<Client>(_clients);
        }

        public static void SetClient(int id, Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("Client cannot be null");
            }

            var clientTmp = _clients.FirstOrDefault(e => e._id == id);
            if (clientTmp is null)
            {
                throw new ArgumentException("There is no client with id : " + id);
            }

            var clientIndex = _clients.FindIndex(e => e._id == id); 
            if (clientIndex == -1)
            {
                throw new InvalidOperationException("There is no client with id : " + id);
            }
            client.SetId(id);
            _clients[clientIndex] = client;
            _clients.Remove(client);
        }

        public void SetId(int Id)
        {
            var client = _clients.FirstOrDefault(e => e._id == Id);
            if (client is null)
            {
                throw new ArgumentNullException("There is no ID: " + Id +" in the client collection");

            }
            _id = Id;
        }

    }
}
