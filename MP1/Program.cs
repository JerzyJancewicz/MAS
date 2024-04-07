using MP1.models;
using MP1.serializers;

namespace MP1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Client client1 = new Client(
                "Jerzy1",
                "Jancewicz1",
                "531531531",
                new Address("Wiosenna 5","Warszawa"),
                "jancewiczjerzy@gmail.com"
            );
            Client client5 = new Client(
                "Jerzy5",
                "Jancewicz5",
                "531531535",
                new Address("Wiosenna 6", "Warszawa"),
                "example@example.com"
            );
            Client client2 = new Client(
                "Jerzy2",
                "Jancewicz2",
                "531531532",
                new Address("Wiosenna 2", "Warszawa")
            );
            Client client4 = new Client(
                "Jerzy4",
                "Jancewicz4",
                "531531534",
                new Address("Wiosenna 4", "Warszawa")
            );
            Client client3 = new Client(
                "Jerzy3",
                "Jancewicz3",
                "531531533",
                new Address("Wiosenna 3", "Warszawa")
            );

            var clients = Client.GetClients();

            foreach (var client in clients)
            {
                Console.WriteLine(client);
            }
            string FilePath = "yourFile";
            ClientSerializer.SerializeClients(clients,FilePath);
            ClientSerializer.DeserializeClients(FilePath);
        }
    }
}