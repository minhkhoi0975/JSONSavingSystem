using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SavingSystem;
using System.IO;

namespace SavingSystem.Test
{
    public class TestSavingEntities : MonoBehaviour
    {
        [SerializeField] private string saveFileName = "sceneInfo.json";

        private SaveData saveData;
        private Serializer serializer;

        private void Awake()
        {
            saveData = new SaveData();
            serializer = new Serializer();
        }

        [ContextMenu("Load Data")]
        public void LoadData()
        {
            // Read serialized data from the save file.
            string filePath = $"{Application.persistentDataPath}/{saveFileName}";
            StreamReader streamReader = new StreamReader(filePath);
            string jsonObject = streamReader.ReadToEnd();
            streamReader.Close();

            // Deserialize the data.
            saveData = serializer.Deserialize<SaveData>(jsonObject);

            // Load data for each entity.
            Entity[] allEntities = FindObjectsOfType<Entity>(true);
            foreach (var entity in allEntities)
                entity.LoadData(saveData);

            Debug.Log($"Load data from {filePath}");
        }

        [ContextMenu("Save Data")]
        public void SaveData()
        {
            // Update data in the save data.
            Entity[] allEntities = FindObjectsOfType<Entity>(true);
            foreach (var entity in allEntities)
                entity.SaveData(saveData);

            // Serialize the data.
            object jsonObject = serializer.Serialize(saveData);

            // Save the serialized data to a file.
            string filePath = $"{Application.persistentDataPath}/{saveFileName}";
            StreamWriter streamWriter = new StreamWriter(filePath, false);
            streamWriter.Write(jsonObject);
            streamWriter.Close();

            Debug.Log($"Saved data to {filePath}");
        }
    }
}
