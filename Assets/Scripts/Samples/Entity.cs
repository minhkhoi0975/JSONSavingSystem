using System;
using UnityEngine;
using SavingSystem;

namespace SavingSystem.Test
{
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
            SaveData entityData = saveData.GetValue<SaveData>($"entity_{guid}");

            transform.position = entityData.GetValue<Vector3>("position");
            transform.rotation = entityData.GetValue<Quaternion>("rotation");
            transform.localScale = entityData.GetValue<Vector3>("scale");
        }

        public void SaveData(SaveData saveData)
        {
            SaveData entityData = new SaveData();
            entityData.SetValue<Vector3>("position", transform.position);
            entityData.SetValue<Quaternion>("rotation", transform.rotation);
            entityData.SetValue<Vector3>("scale", transform.localScale);

            saveData.SetValue<SaveData>($"entity_{guid}", entityData);
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
