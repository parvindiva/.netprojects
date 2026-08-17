using System.ComponentModel.DataAnnotations;

namespace GiveAID.Models
{
    /// <summary>
    /// Partner - companies associated with Give-AID.
    /// Displayed on "Our Partners" page.
    /// </summary>
    public class Partner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Partner name is required")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(300)]
        public string? LogoUrl { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }

        [StringLength(300)]
        public string? Website { get; set; }

        public int DisplayOrder { get; set; } = 0;

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
