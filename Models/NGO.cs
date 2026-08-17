using System.ComponentModel.DataAnnotations;

namespace GiveAID.Models
{
    /// <summary>
    /// NGO stores details of associated Non-Governmental Organizations.
    /// Admin manages these; users view the list.
    /// </summary>
    public class NGO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "NGO name is required")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        [StringLength(300)]
        public string? LogoUrl { get; set; }

        [StringLength(300)]
        public string? Website { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string? ContactEmail { get; set; }

        [StringLength(20)]
        public string? ContactPhone { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
