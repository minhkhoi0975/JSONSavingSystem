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
                saveDataEntries[entryName] = saveDataEntry;
            }

            // Set the value of the data entry.
            saveDataEntry.SetValue(value);
        }

        public T GetValue<T>(string entryName)
        {
            return saveDataEntries[entryName].GetValue<T>();
        }
    }
}
