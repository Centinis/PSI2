using System.Text.Json;
using Collibri.Dtos;
using Collibri.Repositories.DataHandling;

namespace Collibri.Repositories.FileBasedImplementation.DataHandling
{
    public class DataHandler : IDataHandler
    {
        private readonly string _dataDirectory
            = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory())?.FullName, "Collibri", "Data");

        public List<T> GetAllItems<T>(ModelType type) where T : class, new() 
        {
            string data = File.ReadAllText(Path.Combine(_dataDirectory, $"{type.ToString()}.json"));
            
            return JsonSerializer.Deserialize<List<T>>(data) ?? throw new InvalidOperationException();
        }

        public void PostAllItems<T>(List<T> itemList, ModelType type) where T : class, new() 
        {
            string data = JsonSerializer.Serialize(itemList, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(Path.Combine(_dataDirectory, $"{type.ToString()}.json"), data);
        }
    }
}
