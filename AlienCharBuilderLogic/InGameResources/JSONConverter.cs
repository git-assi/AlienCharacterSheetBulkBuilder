using Newtonsoft.Json;


namespace AlienCharBuilderLogic.InGameResources
{
    public class JSONConverter
    {
        public static T ReadJsonFromFile<T>(string filePath)
        {
            string jsonContent = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<T>(jsonContent);
        }

        public static void WriteObjectToJsonFile<T>(string filePath, T data)
        {
            string jsonContent = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, jsonContent);


        }
    }
}
