using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiveAID.Models
{
    /// <summary>
    /// Records when a user expresses interest in a programme.
    /// </summary>
    public class ProgrammeInterest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProgrammeId { get; set; }

        public DateTime ExpressedDate { get; set; } = DateTime.Now;

        [StringLength(500)]
        public string? Message { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("ProgrammeId")]
        public Programme? Programme { get; set; }
    }
}
