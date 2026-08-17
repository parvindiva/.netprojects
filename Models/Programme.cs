using System.ComponentModel.DataAnnotations;

namespace GiveAID.Models
{
    /// <summary>
    /// Programme - welfare activities/events conducted by NGO.
    ///A Categories: Education, HealthCare, PrivilegedChildren.
    /// </summary>
    public class Programme
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Programme title is required")]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(5000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Category { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [StringLength(300)]
        public string? Venue { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
