using MP1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MP1.serializers
{
    public class ClientSerializer
    {
        public static void SerializeClients(List<Client> clients, string FilePath)
        {
            string json = JsonSerializer.Serialize(clients);
            try
            {
                CreateFileIfNotExists(FilePath);
                File.WriteAllText(FilePath, json);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public static void CreateFileIfNotExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                try
                {
                    FileStream fs = File.Create(filePath);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static List<Client> DeserializeClients(string filePath)
        {
            string json = File.ReadAllText(filePath);
            List<Client> clients = JsonSerializer.Deserialize<List<Client>>(json);
            return clients;
        }
    }
}
