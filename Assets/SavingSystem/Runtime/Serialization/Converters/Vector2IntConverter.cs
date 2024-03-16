using UnityEngine;
using Newtonsoft.Json;

namespace SavingSystem
{
    public class Vector2IntConverter : PartialConverter<Vector2Int>
    {
        protected override void ReadValue(ref Vector2Int value, string name, JsonReader reader, JsonSerializer serializer)
        {
            switch (name)
            {
                case nameof(value.x):
                    value.x = reader.ReadAsInt32() ?? 0;
                    break;
                case nameof(value.y):
                    value.y = reader.ReadAsInt32() ?? 0;
                    break;
            }
        }

        protected override void WriteJsonProperties(JsonWriter writer, Vector2Int value, JsonSerializer serializer)
        {
            writer.WritePropertyName(nameof(value.x));
            writer.WriteValue(value.x);
            writer.WritePropertyName(nameof(value.y));
            writer.WriteValue(value.y);
        }
    }
}
