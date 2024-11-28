using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace JSONDispatcher.Services
{
    public class DispatcherService<T>
    {
        public List<T> LoadFromFile(string filePath)
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        public void SaveToFile(string filePath, List<T> data)
        {
            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
    }
}
