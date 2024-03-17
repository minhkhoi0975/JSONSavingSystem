using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using SavingSystem;
using System.Linq;
using JetBrains.Annotations;

namespace SavingSystem.Test
{
    public class TestSerializingDataSaveData
    {
        [Test]
        public void TestSerializingSaveData()
        {
            SaveData saveData = new SaveData();
            saveData.SetValue("Name", "Roberts");
            saveData.SetValue("Age", 23);
            saveData.SetValue("IsFemale", false);
            saveData.SetValue("CurrentHealth", 60.0f);
            saveData.SetValue("Personality", new string[] { "kind", "noble", "generous" });

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(saveData);
            Assert.AreNotEqual(jsonObject, null);

            SaveData saveData2 = serializer.Deserialize<SaveData>(jsonObject);
            Assert.AreNotEqual(saveData2, null);

            Assert.AreEqual(saveData.GetValue<string>("Name"), saveData2.GetValue<string>("Name"));
            Assert.AreEqual(saveData.GetValue<int>("Age"), saveData2.GetValue<int>("Age"));
            Assert.AreEqual(saveData.GetValue<bool>("IsFemale"), saveData2.GetValue<bool>("IsFemale"));
            Assert.AreEqual(saveData.GetValue<float>("CurrentHealth"), saveData2.GetValue<float>("CurrentHealth"));
            Assert.AreEqual(saveData.GetValue<string[]>("Personality"), saveData2.GetValue<string[]>("Personality"));
        }

        public enum Quality
        {
            Low = 0,
            Medium = 1,
            High = 2,
            Ultra = 3,
        }

        [Test]
        public void TestSerializingSaveData2()
        {
            SaveData gameSettings = new SaveData();

            gameSettings.SetValue("Screen Resolution", new Vector2Int(1920, 1080));
            gameSettings.SetValue("Window Mode", true);
            gameSettings.SetValue("VSync", false);

            gameSettings.SetValue("Shadow Quality", Quality.Medium);
            gameSettings.SetValue("Grass Quality", Quality.Low);
            gameSettings.SetValue("Texture Quality", Quality.Medium);
            gameSettings.SetValue("Anti Aliasing", Quality.High);
            gameSettings.SetValue("Post Processing", Quality.Ultra);

            gameSettings.SetValue("Master Volume", 30.0f);
            gameSettings.SetValue("SFX Volume", 20.0f);
            gameSettings.SetValue("Dialogue Volume", 16.0f);
            gameSettings.SetValue("Music Volume", 25.0f);
            gameSettings.SetValue("Subtitles Enabled", true);

            gameSettings.SetValue("Mouse Sensitivity", 23.0f);
            gameSettings.SetValue("Invert Mouse Y", false);

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(gameSettings);
            Assert.AreNotEqual(jsonObject, null);

            SaveData gameSettings2 = serializer.Deserialize<SaveData>(jsonObject);
            Assert.AreNotEqual(gameSettings2, null);

            foreach (var gameSetting in gameSettings.saveDataEntries)
            {
                Assert.AreEqual(gameSetting.Value.value, gameSettings2.saveDataEntries[gameSetting.Key].value);
            }
        }
    }
}
