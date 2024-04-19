using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreeCheck.Repository.Infrastructure.Entity
{
    [Table("BrandCheck")]
    public class BrandCheck : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}