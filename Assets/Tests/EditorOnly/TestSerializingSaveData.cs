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
        public void TestSerializingDataEntryBool()
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
    }
}
