using System;
using UnityEngine;

namespace SavingSystem
{
    [System.Serializable]
    public class EntityData
    {
        [SerializeField]
        [DisplayOnlyInInspector]
        private string guid;
        public string Guid => guid;

        public void GenerateGuid()
        {
            guid = System.Guid.NewGuid().ToString();
        }
    }
}
