using UnityEngine;

namespace SavingSystem
{
    public interface IEntityDataSo
    {
        public EntityData GetEntityData();
    }

    public class EntityDataSo<T> : ScriptableObject, IEntityDataSo where T : EntityData
    {
        [SerializeField]
        private T entityData;
        public T EntityData => entityData;

        public EntityData GetEntityData()
        {
            return entityData;
        }
    }
}
