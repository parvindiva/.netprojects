using System.ComponentModel.DataAnnotations;

namespace GiveAID.Models
{
    /// <summary>
    /// GalleryImage - images of programmes conducted by NGO.
    /// </summary>
    public class GalleryImage
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(300)]
        public string ImageUrl { get; set; } = string.Empty;

        [StringLength(200)]
        public string? ProgrammeName { get; set; }

        [StringLength(50)]
        public string? Icon { get; set; }

        public DateTime UploadedDate { get; set; } = DateTime.Now;
    }
}
