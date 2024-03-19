using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SavingSystem
{
    public abstract class EntityObject : MonoBehaviour
    {
        public abstract Entity GetEntity();
    }

    public class EntityObject<T> : EntityObject where T : Entity
    {
        [SerializeField]
        private T entityData;

        public override Entity GetEntity() => entityData;
    }
}
