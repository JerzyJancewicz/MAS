using MP1.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MP1.models
{
    public class Client
    {
        private static List<Client> clients = new List<Client>();

        private int id = 0; // Ekst. trwałości
        private static int nextId = 1;

        private string name;
        private string surname;
        private string? email = null; // atr. opcjonalny
        private Address address { get; set; } // atr. zlozony
        private List<string> phoneNumbers = new List<string>(); // atr. powtarzalny

        private static int numbersOfClient;// atr klasowy
        private string fullName = ""; // atr pochodny t
        public Client(string Name, string Surname, string PhoneNumber, Address Address)
        {
            Validate(Name, Surname, PhoneNumber, Address);

            name = Name;
            surname = Surname;
            address = Address;
            phoneNumbers.Add(PhoneNumber);

            InitializeVariables(Name, Surname);
            clients.Add(this);
        }
        public Client(string Name, string Surname, string PhoneNumber, Address Address, string Email) // przeciazenie
        {
            Validate(Name, Surname, PhoneNumber, Address, Email);

            name = Name;
            surname = Surname;
            address = Address;
            email = Email;
            phoneNumbers.Add(PhoneNumber);

            InitializeVariables(Name, Surname);
            clients.Add(this);
        }

        private static void Validate(string name, string surname, string phoneNumber, Address address)
         {
            ValidateClient.Name(name);
            ValidateClient.Surname(surname);
            ValidateClient.PhoneNumber(phoneNumber);

            ValidateAddress.City(address.City);
            ValidateAddress.Street(address.Street);

        }
        private static void Validate(string name, string surname, string phoneNumber, Address address, string email)
        {
            ValidateClient.Name(name);
            ValidateClient.Surname(surname);
            ValidateClient.PhoneNumber(phoneNumber);
            ValidateClient.Email(email);

            ValidateAddress.City(address.City);
            ValidateAddress.Street(address.Street);
        }

        private void InitializeVariables(string name, string surname)
        {
            id = nextId++;
            numbersOfClient++;
        }

        private string CreateFullName(string name, string surname)
        {
            return name + " " + surname;
        }
        public string Name
        {
            get { return name; }
            set
            {
                ValidateClient.Name(value);
                name = value;
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                ValidateClient.Surname(value);
                surname = value;
            }
        }
        public string? Email
        {
            get { return email; }
            set
            {
                ValidateClient.Email(value);
                email = value;
            }
        }
        public Address Address
        {
            get { return address; }
        }
        public int Id
        {
            get { return id; }
        }
        public ReadOnlyCollection<string> PhoneNumbers
        {
            get { return new ReadOnlyCollection<string>(phoneNumbers); }
        }
        public int NumbersOfClient
        {
            get { return numbersOfClient; }
            set { numbersOfClient = value; }
        }
        public string FullName
        {
            get
            {
                var fullNameCreate = CreateFullName(name, Surname);
                return fullNameCreate;
            }
        }
        public void AddPhoneNumber(string phoneNumber)
        {
            ValidateClient.PhoneNumber(phoneNumber);
            phoneNumbers.Add(phoneNumber);
        }
        public void RemovePhoneNumber(string phoneNumber)
        {
            ValidateClient.PhoneNumber(phoneNumber);
            ValidateClient.PhoneNumbersList(phoneNumber, phoneNumbers);
            phoneNumbers.Remove(phoneNumber);
        }

        // mtd klasowa
        public static ReadOnlyCollection<Client> GetClients()
        {
            return new ReadOnlyCollection<Client>(clients);
        }

        public static void SetClient(int id, Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("Client cannot be null");
            }

            var clientTmp = clients.FirstOrDefault(e => e.id == id);
            if (clientTmp is null)
            {
                throw new ArgumentException("There is no client with id : " + id);
            }

            var clientIndex = clients.FindIndex(e => e.id == id); 
            if (clientIndex == -1)
            {
                throw new InvalidOperationException("There is no client with id : " + id);
            }
            client.SetId(id);
            clients[clientIndex] = client;
        }

        private void SetId(int Id)
        {
            var client = clients.FirstOrDefault(e => e.id == Id);
            if (client is null)
            {
                throw new ArgumentNullException("There is no ID: " + Id +" in the clients collection");

            }
            id = Id;
        }

        public override string ToString()
        {
            return name + " "+ surname +" : " + id;
        }
    }
}
