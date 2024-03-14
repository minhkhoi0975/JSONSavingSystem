using UnityEngine;

namespace SavingSystem
{
    public abstract class EntityScriptableObject: ScriptableObject
    {
        public abstract Entity GetEntity();
    }

    public class EntityScriptableObject<T> : EntityScriptableObject where T : Entity
    {
        [SerializeField]
        private T entityData;
        
        public T GetConcreteEntity()
        {
            return entityData;
        }

        public override Entity GetEntity()
        {
            return entityData;
        }
    }
}
