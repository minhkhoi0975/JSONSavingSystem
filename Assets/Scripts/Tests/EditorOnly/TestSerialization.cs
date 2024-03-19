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
    public class TestSerialization
    {
        [Test]
        public void TestSerializingBool()
        {
            for (int i = 0; i < 100; ++i)
            {
                bool value = UnityEngine.Random.Range(int.MinValue, int.MaxValue) % 2 == 0;

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();

                string valueInJson = (string)serializer.Serialize(value);

                bool value2 = serializer.Deserialize<bool>(valueInJson);

                Assert.AreEqual(value2, value);
            }
        }

        [Test]
        public void TestSerializingInt()
        {
            for (int i = 0; i < 100; ++i)
            {
                int value = UnityEngine.Random.Range(int.MinValue, int.MaxValue);

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();

                string valueInJson = (string)serializer.Serialize(value);

                int value2 = serializer.Deserialize<int>(valueInJson);

                Assert.AreEqual(value2, value);
            }
        }

        [Test]
        public void TestSerializingFloat()
        {
            for (int i = 0; i < 100; ++i)
            {
                float value = UnityEngine.Random.Range(float.MinValue, float.MaxValue);

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();

                string valueInJson = (string)serializer.Serialize(value);

                float value2 = serializer.Deserialize<float>(valueInJson);

                Assert.AreEqual(value2, value);
            }
        }

        [Test]
        public void TestSerializingString()
        {
            for (int i = 0; i < 100; ++i)
            {
                int stringLength = UnityEngine.Random.Range(0, 101);

                string value = "";
                for (int j = 0; j < stringLength; ++j)
                {
                    char randomChar = (char)UnityEngine.Random.Range('!', '~' + 1);
                    value += randomChar;
                }

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();

                string valueInJson = (string)serializer.Serialize(value);

                string value2 = serializer.Deserialize<string>(valueInJson);

                Assert.AreEqual(value2, value);
            }
        }

        public enum TestEnum
        {
            Value1 = 56,
            Value2 = 83,
            Value3 = 104,
            Value4 = 996,
        }

        [Test]
        public void TestSerializingEnum()
        {
            TestEnum value = TestEnum.Value1;

            SavingSystem.Serializer serializer = new SavingSystem.Serializer();

            string valueInJson = (string)serializer.Serialize(value);

            TestEnum value2 = serializer.Deserialize<TestEnum>(valueInJson);
        }

        [Test]
        public void TestSerializingEnum2()
        {
            TestEnum value = TestEnum.Value2;

            SavingSystem.Serializer serializer = new SavingSystem.Serializer();

            string valueInJson = (string)serializer.Serialize(value);

            TestEnum value2 = serializer.Deserialize<TestEnum>(valueInJson);
        }

        [Test]
        public void TestSerializingEnum3()
        {
            TestEnum value = TestEnum.Value3;

            SavingSystem.Serializer serializer = new SavingSystem.Serializer();

            string valueInJson = (string)serializer.Serialize(value);

            TestEnum value2 = serializer.Deserialize<TestEnum>(valueInJson);
        }

        [Test]
        public void TestSerializingEnum4()
        {
            TestEnum value = TestEnum.Value4;

            SavingSystem.Serializer serializer = new SavingSystem.Serializer();

            string valueInJson = (string)serializer.Serialize(value);

            TestEnum value2 = serializer.Deserialize<TestEnum>(valueInJson);
        }

        [Test]
        public void TestSerializingArray()
        {
            for (int i = 0; i < 100; ++i)
            {
                // Generate a random size for the array.
                int randomSize = UnityEngine.Random.Range(0, 101);

                // Generate random elements for the array.
                int[] value = new int[randomSize];
                for (int j = 0; j < randomSize; ++j)
                    value[j] = UnityEngine.Random.Range(int.MinValue, int.MaxValue);

                // Serialize the object.
                SavingSystem.Serializer serializer = new SavingSystem.Serializer();
                string valueInJson = (string)serializer.Serialize(value);

                // Deserialize the object.
                int[] value2 = serializer.Deserialize<int[]>(valueInJson);

                // Check if the lengths are equal.
                Assert.AreEqual(value2.Length, value.Length);

                // Check if the elements are equal.
                for (int j = 0; j < value2.Length; ++j)
                    Assert.AreEqual(value2[j], value[j]);
            }
        }

        [Test]
        public void TestSerializingList()
        {
            for (int i = 0; i < 100; ++i)
            {
                // Generate a random size for the list.
                int randomSize = UnityEngine.Random.Range(0, 101);

                // Generate random elements for the array.
                List<int> value = new List<int>();
                for (int j = 0; j < randomSize; ++j)
                    value.Add(UnityEngine.Random.Range(int.MinValue, int.MaxValue));

                // Serialize the object.
                SavingSystem.Serializer serializer = new SavingSystem.Serializer();
                string valueInJson = (string)serializer.Serialize(value);

                // Deserialize the object.
                List<int> value2 = serializer.Deserialize<List<int>>(valueInJson);

                // Check if the lengths are equal.
                Assert.AreEqual(value2.Count, value.Count);

                // Check if the elements are equal.
                for (int j = 0; j < value2.Count; ++j)
                    Assert.AreEqual(value2[j], value[j]);
            }
        }

        [Test]
        public void TestSerializingHashSet()
        {
            for (int i = 0; i < 100; ++i)
            {
                // Generate a random maximum size for the hash set.
                int randomSize = UnityEngine.Random.Range(0, 101);

                // Generate random elements for the array.
                HashSet<int> value = new HashSet<int>();
                for (int j = 0; j < randomSize; ++j)
                    value.Add(UnityEngine.Random.Range(int.MinValue, int.MaxValue));

                // Serialize the object.
                SavingSystem.Serializer serializer = new SavingSystem.Serializer();
                string valueInJson = (string)serializer.Serialize(value);

                // Deserialize the object.
                List<int> value2 = serializer.Deserialize<List<int>>(valueInJson);

                // Check if the hash sets share the same size.
                Assert.AreEqual(value2.Count, value.Count);

                // Check if each value in value is also in value2.
                foreach(var element in value)
                {
                    Assert.IsTrue(value2.Contains(element));
                }
            }
        }

        [Test]
        public void TestSerializingDictionary()
        {
            for (int i = 0; i < 100; ++i)
            {
                // Generate a dictionary.
                Dictionary<string, float> value = new Dictionary<string, float>();
                int randomSize = UnityEngine.Random.Range(0, 101);
                for (int j = 0; j < randomSize; ++j)
                {
                    // Generate a key.
                    string key = "";
                    int stringLength = UnityEngine.Random.Range(0, 101);
                    for (int k = 0; k < stringLength; ++k)
                    {
                        char randomChar = (char)UnityEngine.Random.Range('!', '~' + 1);
                        key += randomChar;
                    }

                    // Generate a value.
                    float valueOfKey = UnityEngine.Random.Range(float.MinValue, float.MaxValue);

                    // Add key to the dictionary.
                    value[key] = valueOfKey;
                }

                // Serialize the dictionary.
                SavingSystem.Serializer serializer = new SavingSystem.Serializer();
                string valueInJson = (string)serializer.Serialize(value);

                // Deserialize the dictionary.
                Dictionary<string, float> value2 = serializer.Deserialize<Dictionary<string, float>>(valueInJson);

                // Check if the dictionaries share the same size.
                Assert.AreEqual(value2.Count, value.Count);

                // Check if each key in value is also in value2.
                // Also check if the keys have the same value.
                foreach(var keyValuePair in value)
                {
                    Assert.IsTrue(value2.ContainsKey(keyValuePair.Key));
                    Assert.AreEqual(value2[keyValuePair.Key], keyValuePair.Value);
                }
            }
        }
    }
}
