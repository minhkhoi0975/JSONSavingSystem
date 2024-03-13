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
    public class TestSerializingUnityTypes
    {
        [Test]
        public void TestSerializingVector2()
        {
            for (int i = 0; i < 100; ++i)
            {
                Vector2 value = new Vector2
                (
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue)
                );

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();

                string valueInJson = (string)serializer.Serialize(value);

                Vector2 value2 = serializer.Deserialize<Vector2>(valueInJson);

                Assert.AreEqual(value2.x, value.x);
                Assert.AreEqual(value2.y, value.y);
            }
        }

        [Test]
        public void TestSerializingVector2Int()
        {
            for (int i = 0; i < 100; ++i)
            {
                Vector2Int value = new Vector2Int
                (
                    UnityEngine.Random.Range(int.MinValue, int.MaxValue),
                    UnityEngine.Random.Range(int.MinValue, int.MaxValue)
                );

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();

                string valueInJson = (string)serializer.Serialize(value);

                Vector2Int value2 = serializer.Deserialize<Vector2Int>(valueInJson);

                Assert.AreEqual(value2.x, value.x);
                Assert.AreEqual(value2.y, value.y);
            }
        }

        [Test]
        public void TestSerializingVector3()
        {
            for (int i = 0; i < 100; ++i)
            {
                Vector3 value = new Vector3
                (
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue)
                );

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();

                string valueInJson = (string)serializer.Serialize(value);

                Vector3 value2 = serializer.Deserialize<Vector3>(valueInJson);

                Assert.AreEqual(value2.x, value.x);
                Assert.AreEqual(value2.y, value.y);
                Assert.AreEqual(value2.z, value.z);
            }
        }

        [Test]
        public void TestSerializingVector3Int()
        {
            for (int i = 0; i < 100; ++i)
            {
                Vector3Int value = new Vector3Int
                (
                    UnityEngine.Random.Range(int.MinValue, int.MaxValue),
                    UnityEngine.Random.Range(int.MinValue, int.MaxValue),
                    UnityEngine.Random.Range(int.MinValue, int.MaxValue)
                );

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();

                string valueInJson = (string)serializer.Serialize(value);

                Vector3Int value2 = serializer.Deserialize<Vector3Int>(valueInJson);

                Assert.AreEqual(value2.x, value.x);
                Assert.AreEqual(value2.y, value.y);
                Assert.AreEqual(value2.z, value.z);
            }
        }

        [Test]
        public void TestSerializingQuaternion()
        {
            for (int i = 0; i < 100; ++i)
            {
                Quaternion value = new Quaternion
                (
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue)
                );

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();
                string valueInJson = (string)serializer.Serialize(value);

                Quaternion value2 = serializer.Deserialize<Quaternion>(valueInJson);

                Assert.AreEqual(value2.x, value.x);
                Assert.AreEqual(value2.y, value.y);
                Assert.AreEqual(value2.z, value.z);
                Assert.AreEqual(value2.w, value.w);
            }
        }

        [Test]
        public void TestSerializingColor()
        {
            for (int i = 0; i < 100; ++i)
            {
                Color value = new Color
                (
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue),
                    UnityEngine.Random.Range(float.MinValue, float.MaxValue)
                );

                SavingSystem.Serializer serializer = new SavingSystem.Serializer();
                string valueInJson = (string)serializer.Serialize(value);

                Color value2 = serializer.Deserialize<Color>(valueInJson);

                Assert.AreEqual(value2.r, value.r);
                Assert.AreEqual(value2.g, value.g);
                Assert.AreEqual(value2.b, value.b);
                Assert.AreEqual(value2.a, value.a);
            }
        }
    }
}
