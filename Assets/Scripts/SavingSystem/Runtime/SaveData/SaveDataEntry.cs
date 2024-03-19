using System;

namespace SavingSystem
{
    [System.Serializable]
    public class SaveDataEntry
    {
        public string name;
        public Type type;
        public object value;

        public T GetValue<T>()
        {
            return (T)value;
        }

        public void SetValue<T>(T value)
        {
            this.value = value;
            type = typeof(T);
        }
    }
}
