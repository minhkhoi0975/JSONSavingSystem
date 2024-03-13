namespace SavingSystem
{
    public interface ISerializer
    {
        /// <summary> Serializes data into a form that can be stored in a file. </summary>
        public object Serialize(object data);

        /// <summary> Deserializes data so that that it can be used. </summary>
        public T Deserialize<T>(object serializedData);
    }
}
