using System.ComponentModel.DataAnnotations;

namespace FreeCheck.Repository.Infrastructure.Entity
{
    public class ShoeCheck : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Code { get; set; } = "";
        [Required]
        public string Name { get; set; } = "";
        public string? Description { get; set; } = "";
        public bool Checked { get; set; } = false;
        public bool StatusChecker { get; set; }
        public DateTime CheckDateTime { get; set; }
        public Guid BrandId { get; set; }
    }
}
