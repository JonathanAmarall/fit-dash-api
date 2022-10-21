namespace FitDash.Core.DomainObjects

{
    public abstract class EntityBase
    {
        public EntityBase()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public DateTime CreateAt { get; private set; }
        public DateTime? UpdateAt { get; protected set; }
    }
}