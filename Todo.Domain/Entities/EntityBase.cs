namespace Todo.Domain.Entities
{
    public abstract class EntityBase : IEquatable<EntityBase>
    {
        
        public EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public bool Equals(EntityBase other)
        {
            return Id == other.Id;
        }
    }
}