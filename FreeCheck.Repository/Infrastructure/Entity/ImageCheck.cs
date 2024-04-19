using System.ComponentModel.DataAnnotations;

namespace FreeCheck.Repository.Infrastructure.Entity
{
    public class ImageCheck : EntityBase
    {
        [Key]
        public Guid Id { get; set; }
        public bool MainImage { get; set; } = false;
        [Required]
        public string ImageData { get; set; } = "";
        public string Description { get; set; } = "";
        public string FileType { get; set; } = "";
        public string Size { get; set; } = "";
        public string Tags { get; set; } = "";
        public Guid ProductId { get; set; }
    }
}
