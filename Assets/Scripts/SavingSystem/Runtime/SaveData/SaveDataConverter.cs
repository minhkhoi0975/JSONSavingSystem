using System;
using System.Linq;
using Newtonsoft.Json;

namespace SavingSystem
{
    public class SaveDataConverter : PartialConverter<SaveData>
    {
        //private int entryCount;

        protected override void ReadValue(ref SaveData value, string name, JsonReader reader, JsonSerializer serializer)
        {
            JsonConverter[] converters = serializer.Converters.ToArray();

            // Read the number of entries.
            int entryCount = reader.ReadAsInt32() ?? 0;
            reader.Read();

            // Read the entries.
            reader.Read();
            for (int i = 0; i < entryCount; ++i)
            {
                SaveDataEntry saveDataEntry = new SaveDataEntry();

                // Read entry's name.     
                reader.Read();
                saveDataEntry.name = reader.ReadAsString() ?? "";

                // Read entry's type.
                reader.Read();
                string typeAsString = reader.ReadAsString();
                saveDataEntry.type = Type.GetType(typeAsString);

                // Read entry's value.
                reader.Read();
                string valueAsJsonObject = reader.ReadAsString().Trim();
                if (typeof(SaveData).IsAssignableFrom(saveDataEntry.type)) // Handle nested save data.
                    saveDataEntry.value = JsonConvert.DeserializeObject<SaveData>(valueAsJsonObject, converters);
                else
                    saveDataEntry.value = JsonConvert.DeserializeObject(valueAsJsonObject, saveDataEntry.type);

                value.saveDataEntries.Add(saveDataEntry.name, saveDataEntry);
            }
            reader.Read();
        }

        protected override void WriteJsonProperties(JsonWriter writer, SaveData value, JsonSerializer serializer)
        {
            JsonConverter[] converters = serializer.Converters.ToArray();

            writer.WritePropertyName("entryCount");
            writer.WriteValue(value.saveDataEntries.Count);

            writer.WritePropertyName("entries");
            writer.WriteStartObject();
            foreach (var saveDataEntry in value.saveDataEntries)
            {
                writer.WritePropertyName(nameof(saveDataEntry.Value.name));
                writer.WriteValue(saveDataEntry.Value.name);

                writer.WritePropertyName(nameof(saveDataEntry.Value.type));
                writer.WriteValue(saveDataEntry.Value.type.AssemblyQualifiedName);

                writer.WritePropertyName(nameof(saveDataEntry.Value.value));
                string valueAsJsonObject = JsonConvert.SerializeObject(saveDataEntry.Value.value, Formatting.Indented, converters);
                writer.WriteValue(valueAsJsonObject); 
            }
            writer.WriteEndObject();
        }
    }
}
