using MP1.Validators;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private static List<Client> _clients = new List<Client>();

        private int _Id = 0; // Ekst. trwałości
        private static int nextId = 1;

        private string _Name;
        private string _Surname;
        private string? _Email = null; // atr. opcjonalny
        private Address Address { get; set; } // atr. zlozony
        private List<string> _PhoneNumbers = new List<string>(); // atr. powtarzalny

        private static int _NumbersOfClient;// atr klasowy
        private string FullName = ""; // atr pochodny

        // mtd klasowa
        public Client(string name, string surname, string phoneNumber, Address address)
        {
            Validate(name, surname, phoneNumber, address);

            _Name = name;
            _Surname = surname;
            Address = address;
            _PhoneNumbers.Add(phoneNumber);

            InitializeVariables(_Name, _Surname);
        }
        public Client(string name, string surname, string phoneNumber, Address address, string email) // przeciazenie
        {
            Validate(name, surname, phoneNumber, address, email);

            _Name = name;
            _Surname = surname;
            _Email = email;
            Address = address;
            _PhoneNumbers.Add(phoneNumber);

            InitializeVariables(_Name, _Surname);
        }

        private static void Validate(string name, string surname, string phoneNumber, Address address)
        {
            ValidateClient.Name(name);
            ValidateClient.Surname(surname);
            ValidateClient.PhoneNumber(phoneNumber);

            ValidateAddress.City(address.City);
            ValidateAddress.Street(address.Street);

        }
        private void Validate(string name, string surname, string phoneNumber, Address address, string email)
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
            _Id = nextId++;
            _NumbersOfClient++;
            _clients.Add(this);
            FullName = CreateFullName(name, surname);
        }

        private string CreateFullName(string name, string surname)
        {
            return name + " " + surname;
        }

        public void AddPhoneNumber(string phoneNumber)
        {
            ValidateClient.PhoneNumber(phoneNumber);
            _PhoneNumbers.Add(phoneNumber);
        }

        public void RemovePhoneNumber(string phoneNumber)
        {
            ValidateClient.PhoneNumber(phoneNumber);
            ValidateClient.PhoneNumbersList(phoneNumber, _PhoneNumbers);
            _PhoneNumbers.Remove(phoneNumber);
        }

        public ReadOnlyCollection<string> GetPhoneNumbers()
        {
            return new ReadOnlyCollection<string>(_PhoneNumbers);
        }

        public void SetName(string name)
        {
            ValidateClient.Name(name);
            _Name = name;
        }
        public string GetName()
        {
            return _Name;
        }
        public void SetSurname(string surname)
        {
            ValidateClient.Surname(surname);
            _Surname = surname;
        }
        public string GetSurname()
        {
            return _Surname;
        }

        public void SetEmail(string email)
        {
            ValidateClient.Email(email);
            _Email = email;
        }
        public string GetEmail()
        {
            return _Email ?? "";
        }

        public static ReadOnlyCollection<Client> GetClients()
        {
            return new ReadOnlyCollection<Client>(_clients);
        }

        public static int getNumbersOfClients()
        {
            return _NumbersOfClient;
        }

        public static void SetClient(int id, Client client)
        {
            if (client == null)
            {
                throw new ArgumentNullException("Client cannot be null");
            }

            var clientTmp = _clients.FirstOrDefault(e => e._Id == id);
            if (clientTmp is null)
            {
                throw new ArgumentException("There is no client with id : " + id);
            }

            var clientIndex = _clients.FindIndex(e => e._Id == id); 
            if (clientIndex == -1)
            {
                throw new InvalidOperationException("There is no client with id : " + id);
            }
            client.SetId(id);
            _clients[clientIndex] = client;
        }

        private void SetId(int Id)
        {
            var client = _clients.FirstOrDefault(e => e._Id == Id);
            if (client is null)
            {
                throw new ArgumentNullException("There is no ID: " + Id +" in the clients collection");

            }
            _Id = Id;
        }
    }
}
