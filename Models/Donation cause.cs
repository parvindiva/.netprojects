using System.ComponentModel.DataAnnotations;

namespace GiveAID.Models
{
    /// <summary>
    /// DonationCause - categories users can donate to.
    /// Examples: Children, Education, Disabled, Woman, Youth, Elderly.
    /// </summary>
    public class DonationCause
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Cause name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(1000)]
        public string? Description { get; set; }

        [StringLength(50)]
        public string? Icon { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
