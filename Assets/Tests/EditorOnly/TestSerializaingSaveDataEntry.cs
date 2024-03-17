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
    public class TestSerializingDataEntry
    {
        [Test]
        public void TestSerializingDataEntryBool()
        {
            SaveDataEntry boolSaveDataEntry = new SaveDataEntry();
            boolSaveDataEntry.name = "SampleBoolEntry";
            boolSaveDataEntry.SetValue(true);

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(boolSaveDataEntry);
            Assert.AreNotEqual(jsonObject, null);

            SaveDataEntry boolSaveDataEntry2 = serializer.Deserialize<SaveDataEntry>(jsonObject);
            Assert.AreNotEqual(boolSaveDataEntry2, null);

            Assert.AreEqual(boolSaveDataEntry2.name, boolSaveDataEntry.name);
            Assert.AreEqual(boolSaveDataEntry2.type, boolSaveDataEntry.type);
            Assert.AreEqual(boolSaveDataEntry2.value, boolSaveDataEntry.value);
        }

        [Test]
        public void TestSerializingDataEntryInt()
        {
            SaveDataEntry intSaveDataEntry = new SaveDataEntry();
            intSaveDataEntry.name = "SampleIntEntry";
            intSaveDataEntry.SetValue(16);

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(intSaveDataEntry);
            Assert.AreNotEqual(jsonObject, null);

            SaveDataEntry intSaveDataEntry2 = serializer.Deserialize<SaveDataEntry>(jsonObject);
            Assert.AreNotEqual(intSaveDataEntry2, null);

            Assert.AreEqual(intSaveDataEntry2.name, intSaveDataEntry.name);
            Assert.AreEqual(intSaveDataEntry2.type, intSaveDataEntry.type);
            Assert.AreEqual(intSaveDataEntry2.value, intSaveDataEntry.value);
        }

        [Test]
        public void TestSerializingDataEntryFloat()
        {
            SaveDataEntry floatSaveDataEntry = new SaveDataEntry();
            floatSaveDataEntry.name = "SampleFloatEntry";
            floatSaveDataEntry.SetValue(16.0f);

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(floatSaveDataEntry);
            Assert.AreNotEqual(jsonObject, null);

            SaveDataEntry floatSaveDataEntry2 = serializer.Deserialize<SaveDataEntry>(jsonObject);
            Assert.AreNotEqual(floatSaveDataEntry2, null);

            Assert.AreEqual(floatSaveDataEntry2.name, floatSaveDataEntry.name);
            Assert.AreEqual(floatSaveDataEntry2.type, floatSaveDataEntry.type);
            Assert.AreEqual(floatSaveDataEntry2.value, floatSaveDataEntry.value);
        }

        [Test]
        public void TestSerializingDataEntryString()
        {
            SaveDataEntry stringSaveDataEntry = new SaveDataEntry();
            stringSaveDataEntry.name = "SampleStringEntry";
            stringSaveDataEntry.SetValue("Andy");

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(stringSaveDataEntry);
            Assert.AreNotEqual(jsonObject, null);

            SaveDataEntry stringSaveDataEntry2 = serializer.Deserialize<SaveDataEntry>(jsonObject);
            Assert.AreNotEqual(stringSaveDataEntry2, null);

            Assert.AreEqual(stringSaveDataEntry2.name, stringSaveDataEntry.name);
            Assert.AreEqual(stringSaveDataEntry2.type, stringSaveDataEntry.type);
            Assert.AreEqual(stringSaveDataEntry2.value, stringSaveDataEntry.value);
        }

        [Test]
        public void TestSerializingDataEntryVector3()
        {
            SaveDataEntry vector3SaveDataEntry = new SaveDataEntry();
            vector3SaveDataEntry.name = "SampleVector3Entry";
            vector3SaveDataEntry.SetValue(new Vector3 (9.0f, 16.0f, 20.0f));

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(vector3SaveDataEntry);
            Assert.AreNotEqual(jsonObject, null);

            SaveDataEntry vector3SaveDataEntry2 = serializer.Deserialize<SaveDataEntry>(jsonObject);
            Assert.AreNotEqual(vector3SaveDataEntry2, null);
            
            Assert.AreEqual(vector3SaveDataEntry2.name, vector3SaveDataEntry.name);
            Assert.AreEqual(vector3SaveDataEntry2.type, vector3SaveDataEntry.type);
            Assert.AreEqual(vector3SaveDataEntry2.value, vector3SaveDataEntry.value);
        }

        [Test]
        public void TestSerializingDataEntryQuaternion()
        {
            SaveDataEntry quaternionSaveDataEntry = new SaveDataEntry();
            quaternionSaveDataEntry.name = "SampleQuaternionEntry";
            quaternionSaveDataEntry.SetValue(new Quaternion(9.0f, 16.0f, 20.0f, 20.0f));

            Serializer serializer = new Serializer();
            string jsonObject = (string)serializer.Serialize(quaternionSaveDataEntry);
            Assert.AreNotEqual(jsonObject, null);

            SaveDataEntry quaternionSaveDataEntry2 = serializer.Deserialize<SaveDataEntry>(jsonObject);
            Assert.AreNotEqual(quaternionSaveDataEntry2, null);
            
            Assert.AreEqual(quaternionSaveDataEntry2.name, quaternionSaveDataEntry.name);
            Assert.AreEqual(quaternionSaveDataEntry2.type, quaternionSaveDataEntry.type);
            Assert.AreEqual(quaternionSaveDataEntry2.value, quaternionSaveDataEntry.value);
        }
    }
}
