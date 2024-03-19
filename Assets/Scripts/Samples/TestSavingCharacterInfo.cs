using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using SavingSystem;

namespace SavingSystem.Test
{
    public class TestSavingCharacterInfo : MonoBehaviour
    {
        [SerializeField] private string saveFileName = "characterInfo.json";

        [SerializeField] private TMP_InputField inputFieldName;
        [SerializeField] private TMP_InputField inputFieldAge;
        [SerializeField] private TMP_InputField inputFieldScore;
        [SerializeField] private TMP_InputField inputFieldClub;
        [SerializeField] private TMP_InputField inputFieldFriends;
        [SerializeField] private TMP_InputField inputFieldLikes;
        [SerializeField] private TMP_InputField inputFieldDislikes;

        private SaveData saveData;
        private Serializer serializer;

        private void Awake()
        {
            saveData = new SaveData();
            serializer = new Serializer();
        }

        public void SaveData()
        {
            // Set data.
            saveData.SetValue<string>("Name", inputFieldName.text);
            saveData.SetValue<int>("Age", int.Parse(inputFieldAge.text));
            saveData.SetValue<float>("Score", float.Parse(inputFieldScore.text));
            saveData.SetValue<string>("Club", inputFieldClub.text);
            saveData.SetValue<string>("Friends", inputFieldFriends.text);
            saveData.SetValue<string>("Likes", inputFieldLikes.text);
            saveData.SetValue<string>("Dislikes", inputFieldDislikes.text);

            // Serialize the data.
            object jsonObject = serializer.Serialize(saveData);

            // Save the serialized data to a file.
            string filePath = $"{Application.persistentDataPath}/{saveFileName}";
            StreamWriter streamWriter = new StreamWriter(filePath, false);
            streamWriter.Write(jsonObject);
            streamWriter.Close();

            Debug.Log($"Data has been saved to {filePath}");
        }

        public void LoadData()
        {
            // Read serialized data from the save file.
            string filePath = $"{Application.persistentDataPath}/{saveFileName}";
            StreamReader streamReader = new StreamReader(filePath);
            string jsonObject = streamReader.ReadToEnd();
            streamReader.Close();

            // Deserialize the data.
            saveData = serializer.Deserialize<SaveData>(jsonObject);

            // Display data.
            inputFieldName.text = saveData.GetValue<string>("Name");
            inputFieldAge.text = saveData.GetValue<int>("Age").ToString();
            inputFieldScore.text = saveData.GetValue<float>("Score").ToString();
            inputFieldClub.text = saveData.GetValue<string>("Club");
            inputFieldFriends.text = saveData.GetValue<string>("Friends");
            inputFieldLikes.text = saveData.GetValue<string>("Likes");
            inputFieldDislikes.text = saveData.GetValue<string>("Dislikes");
        }
    }
}
