using MP1.models;
using MP1.serializers;

namespace MP1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Client client = new Client();
            Client client1 = new Client();
            Client client2 = new Client();

            var clients = Client.GetClients();
            Console.WriteLine(clients.Count());
            Client.SetClient(2, new Client());
            Console.WriteLine(clients.Count());
            string FilePath = "F:\\PROJEKTY\\C#Projects\\mas\\MAS\\MP1\\serializedObjects\\clients.json";
            ClientSerializer.SerializeClients(Client.GetClients().ToList() ,FilePath);
        }
    }
}