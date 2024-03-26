using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

namespace SavingSystem.Test
{
    public class TestSerializingSaveData
    {
        [Test]
        public void TestSerializingSaveData1()
        {
            SaveData saveData = new SaveData();
            saveData.SetValue("Name", "Roberts");
            saveData.SetValue("Age", 23);
            saveData.SetValue("IsFemale", false);
            saveData.SetValue("CurrentHealth", 60.0f);
            saveData.SetValue("Personality", new string[] { "kind", "noble", "generous" });

            HashSet<string> factions = new HashSet<string>
            {
                "Kingdom of Sardinia",
                "Kingdom of Sardinia",
                "Black Cloak Knight",
                "Lion Military Order"
            };
            saveData.SetValue("Factions", factions);

            Dictionary<string, float> relations = new Dictionary<string, float>
            {
                { "Kingdom of Kovarlasca", 100.0f },
                { "Red Eagle Cult", -30.0f },
                { "Demons of Nubrus Dungeon.", -100.0f }
            };
            saveData.SetValue("Relations", relations);

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

        public struct KeyBinding
        {
            public char moveForward;
            public char moveBackward;
            public char moveLeft;
            public char moveRight;
            public char jump;
            public char crouch;

            public char interact;
            public char primaryAction;
            public char secondaryAction;

            public char weapon1;
            public char weapon2;
            public char weapon3;
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
            gameSettings.SetValue("Key Binding", new KeyBinding
            {
                moveForward = 'W',
                moveBackward = 'S',
                moveLeft = 'A',
                moveRight = 'D',
                jump = ' ',
                crouch = 'C',
                interact = 'E',
                primaryAction = 'L',
                secondaryAction = 'R',
                weapon1 = '1',
                weapon2 = '2',
                weapon3 = '3'
            });

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(gameSettings);
            Assert.AreNotEqual(jsonObject, null);

            SaveData gameSettings2 = serializer.Deserialize<SaveData>(jsonObject);
            Assert.AreNotEqual(gameSettings2, null);

            foreach (var gameSetting in gameSettings.saveDataEntries)
                Assert.AreEqual(gameSetting.Value.value, gameSettings2.saveDataEntries[gameSetting.Key].value);
        }

        [System.Serializable]
        class DerivedSaveData : SaveData
        {
            public DerivedSaveData() 
            {
                SetValue("Difficulty", "Normal");
                SetValue("Platform", "PC");
                SetValue("Screen Resolution", new Vector2Int(1920, 1080));

                List<string> factions = new List<string>() 
                {
                    "Kingdom of Sardinia",
                    "Kingdom of Sardinia",
                    "Black Cloak Knight",
                    "Lion Military Order"
                };
                SetValue("Factions", factions);

                Queue<string> craftingQueue = new Queue<string>();
                craftingQueue.Enqueue("Steel Sword");
                craftingQueue.Enqueue("Hide Armor");
                craftingQueue.Enqueue("Arrow");
                SetValue("Crafting queue", craftingQueue);
            }
        }

        [Test]
        public void TestSerializingSaveData3()
        {
            DerivedSaveData derivedSaveData = new DerivedSaveData();
            derivedSaveData.SetValue("Player Name", "Roberts");

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(derivedSaveData);
            Assert.AreNotEqual(jsonObject, null);

            DerivedSaveData derivedSaveData2 = serializer.Deserialize<DerivedSaveData>(jsonObject);
            Assert.AreNotEqual(derivedSaveData2, null);

            foreach (var gameSetting in derivedSaveData.saveDataEntries)
                Assert.AreEqual(gameSetting.Value.value, derivedSaveData2.saveDataEntries[gameSetting.Key].value);
        }
    }
}
