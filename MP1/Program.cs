using MP1.models;
using MP1.serializers;

namespace MP1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Client client = new Client(
                "Jerzy",
                "Jancewicz",
                "531531531",
                new Address("Wiosenna 5","Warszawa")
            );
            Client client2 = new Client(
                "Jerzy2",
                "Jancewicz2",
                "531531532",
                new Address("Wiosenna 2", "Warszawa")
            );
            Client client3 = new Client(
                "Jerzy3",
                "Jancewicz3",
                "531531533",
                new Address("Wiosenna 3", "Warszawa")
            );

            var clients = Client.GetClients();
            Console.WriteLine(clients.Count());

            Client.SetClient(2, client3);
            Console.WriteLine(clients.Count());

            string FilePath = "F:\\PROJEKTY\\C#Projects\\mas\\MAS\\MP1\\serializedObjects\\clients.json";
            ClientSerializer.SerializeClients(Client.GetClients().ToList() ,FilePath);
        }
    }
}