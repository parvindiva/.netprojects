using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiveAID.Models
{
    /// <summary>
    /// Invite - when a user sends email invitation to a friend.
    /// </summary>
    public class Invite
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string InviteeEmail { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Message { get; set; }

        public DateTime SentDate { get; set; } = DateTime.Now;

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
