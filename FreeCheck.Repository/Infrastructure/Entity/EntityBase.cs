namespace FreeCheck.Repository.Infrastructure.Entity
{
    public abstract class EntityBase
    {
        public string? ExtraProperties { get; set; }
        public string? ConcurrencyStamp { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public Guid? LastModifierId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Guid? DeleterId { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
