using System;
using System.Collections.Generic;

namespace SavingSystem
{
    /// <summary>
    /// Used for storing data that can be serialized and saved to a file. <br/>
    /// NOTE: You can derive this class to initialize entries in saveDataEntries, but variables in derived classes are NOT guaranteed be serialized.
    /// </summary>
    [System.Serializable]
    public class SaveData
    {
        public Dictionary<string, SaveDataEntry> saveDataEntries = new Dictionary<string, SaveDataEntry>();

        public void SetValue<T>(string entryName, T value)
        {
            // Get the existing data entry, or create a new one if it hasn't existed.
            SaveDataEntry saveDataEntry;
            if (!saveDataEntries.TryGetValue(entryName, out saveDataEntry)) 
            {
                saveDataEntry = new SaveDataEntry();
                saveDataEntry.name = entryName;
                saveDataEntries[entryName] = saveDataEntry;
            }

            // Set the value of the data entry.
            saveDataEntry.SetValue(value);
        }

        public T GetValue<T>(string entryName)
        {
            return saveDataEntries[entryName].GetValue<T>();
        }

        public bool TryGetValue<T>(string entryName, out T value) 
        {
            if (!saveDataEntries.TryGetValue(entryName, out SaveDataEntry saveDataEntry))
            {
                value = default(T);
                return false;
            }

            // Check if the concrete type of the entry is compatible with type T.
            Type concreteType = saveDataEntry.value.GetType();
            if (!typeof(T).IsAssignableFrom(concreteType))
            {
                value = default(T);
                return false;
            }

            value = saveDataEntry.GetValue<T>();
            return true;
        }
    }
}
