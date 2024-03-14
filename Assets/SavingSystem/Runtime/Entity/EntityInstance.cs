namespace SavingSystem
{
    [System.Serializable]
    public class EntityInstance
    {
        private string guid;

        private Entity entity;
        public Entity Entity => entity;

        public EntityInstance(Entity entity) 
        {
            GenerateId();
            this.entity = entity;
        }

        private void GenerateId()
        {
            guid = System.Guid.NewGuid().ToString();
        }
    }
}
