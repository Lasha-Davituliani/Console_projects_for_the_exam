using Newtonsoft.Json;

namespace FileOperations
{
    public class FileOperations
    {
        public static List<T> LoadFromFile<T>(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            return new List<T>();
        }

        public static void SaveToFile<T>(List<T> data, string filePath)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }
    }
}
