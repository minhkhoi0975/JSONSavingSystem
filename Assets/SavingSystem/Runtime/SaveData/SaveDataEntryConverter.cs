using System;
using Newtonsoft.Json;

namespace SavingSystem
{
    public class SaveDataEntryConverter : PartialConverter<SaveDataEntry>
    {
        protected override void ReadValue(ref SaveDataEntry value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.name):
                    value.name = reader.ReadAsString() ?? "";
                    break;
                case nameof(value.type):
                    string typeAsString = reader.ReadAsString();
                    value.type = Type.GetType(typeAsString);
                    break;
                case nameof(value.value):
                    string valueAsJsonObject = reader.ReadAsString().Trim();
                    value.value = JsonConvert.DeserializeObject(valueAsJsonObject, value.type);
                    //value.value = Convert.ChangeType(valueAsJsonObject, value.type);
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, SaveDataEntry value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.name));
            writer.WriteValue(value.name);

            writer.WritePropertyName(nameof(value.type));
            writer.WriteValue(value.type.FullName);

            writer.WritePropertyName(nameof(value.value));
            serializer.Serialize(writer, value.value);
        }
    }
}
