using Newtonsoft.Json;

namespace SavingSystem
{
    public class Serializer
    {
        public JsonSerializerSettings serializerSettings = new JsonSerializerSettings();

        public Serializer() 
        {
            serializerSettings.Converters.Add(new Vector2Converter());
            serializerSettings.Converters.Add(new Vector2IntConverter());
            serializerSettings.Converters.Add(new Vector3Converter());
            serializerSettings.Converters.Add(new Vector3IntConverter());
            serializerSettings.Converters.Add(new QuaternionConverter());
            serializerSettings.Converters.Add(new ColorConverter());
        }

        /// <summary> Serialize data into a form that can be stored in a file. /// </summary>
        public object Serialize(object data)
        {
            string jsonObject = JsonConvert.SerializeObject(data, Formatting.Indented, serializerSettings);
            return jsonObject;
        }

        /// <summary> Deserialize data into a form that can be used by the game./// </summary>
        public T Deserialize<T>(object serializedData)
        {
            return JsonConvert.DeserializeObject<T>(serializedData.ToString());
        }
    }
}
