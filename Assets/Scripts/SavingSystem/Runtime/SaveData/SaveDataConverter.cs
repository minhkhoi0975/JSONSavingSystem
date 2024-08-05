using System;
using System.Linq;
using Newtonsoft.Json;

namespace SavingSystem
{
    public class SaveDataConverter : PartialConverter<SaveData>
    {
        private int entryCount;

        protected override void ReadValue(ref SaveData value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case "entryCount":
                    entryCount = reader.ReadAsInt32() ?? 0;
                    break;

                case "entries":
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
                        saveDataEntry.value = JsonConvert.DeserializeObject(valueAsJsonObject, saveDataEntry.type);

                        value.saveDataEntries.Add(saveDataEntry.name, saveDataEntry);
                    }
                    reader.Read();

                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, SaveData value, JsonSerializer serializer)
        {
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
                string valueAsJsonObject = JsonConvert.SerializeObject(saveDataEntry.Value.value, Formatting.Indented, serializer.Converters.ToArray());
                writer.WriteValue(valueAsJsonObject);
            }
            writer.WriteEndObject();
        }
    }
}
