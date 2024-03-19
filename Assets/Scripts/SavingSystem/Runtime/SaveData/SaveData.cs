using System.Collections.Generic;

namespace SavingSystem
{
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
