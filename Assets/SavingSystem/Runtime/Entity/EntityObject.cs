using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SavingSystem
{
    public abstract class EntityObject : MonoBehaviour
    {
        public abstract EntityData GetEntityData();
    }
}
