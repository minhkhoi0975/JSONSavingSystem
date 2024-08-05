using Newtonsoft.Json;

namespace SavingSystem
{
    public class Serializer : ISerializer
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

            serializerSettings.Converters.Add(new SaveDataEntryConverter());
            serializerSettings.Converters.Add(new SaveDataConverter());
        }

        public object Serialize(object data)
        {
            string jsonObject = JsonConvert.SerializeObject(data, Formatting.Indented, serializerSettings);
            return jsonObject;
        }

        public T Deserialize<T>(object serializedData)
        {
            return JsonConvert.DeserializeObject<T>(serializedData.ToString(), serializerSettings);
        }

        /// <summary> Adds a custom converter for the serializer. </summary>
        public void AddConverter(JsonConverter converter)
        {
            serializerSettings.Converters.Add(converter);
        }
    }
}
