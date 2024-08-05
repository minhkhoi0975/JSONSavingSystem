using System;
using UnityEngine;
using SavingSystem;

namespace SavingSystem.Test
{
    [Serializable]
    public struct EntityData
    {
        public Vector3 position;
        public Quaternion rotation;
        public Vector3 scale;
    }

    public class Entity : MonoBehaviour
    {
        [SerializeField] private string guid;

        private void OnValidate()
        {
            if (!IsGuidValid())
                GenerateGuid();
        }

        public void LoadData(SaveData saveData)
        {
            EntityData entityData;
            if (!saveData.TryGetValue<EntityData>($"entity_{guid}", out entityData))
                return;

            transform.position = entityData.position;
            transform.rotation = entityData.rotation;
            transform.localScale = entityData.scale;
        }

        public void SaveData(SaveData saveData)
        {
            EntityData entityData = new EntityData();
            entityData.position = transform.position;
            entityData.rotation = transform.rotation;
            entityData.scale = transform.localScale;

            saveData.SetValue<EntityData>($"entity_{guid}", entityData);
        }

        private bool IsGuidValid()
        {
            // Check if the guid is empty.
            if (string.IsNullOrEmpty(guid))
                return false;

            // Check if the guid is already used by another gameobject in the scene.
            Entity[] allEntitiesInScene = FindObjectsOfType<Entity>(true);
            foreach (Entity entity in allEntitiesInScene)
            {
                if (entity != this && entity.guid == guid)
                    return false;
            }

            return true;
        }

        private void GenerateGuid()
        {
            Guid guid = Guid.NewGuid();
            this.guid = guid.ToString();
        }
    }
}
