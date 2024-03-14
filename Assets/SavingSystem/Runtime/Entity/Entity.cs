using System;
using UnityEngine;

namespace SavingSystem
{
    [System.Serializable]
    public class Entity
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
