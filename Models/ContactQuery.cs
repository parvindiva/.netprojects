using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiveAID.Models
{
    /// <summary>
    /// ContactQuery - user support requests and queries.
    /// Admin can view and reply.
    /// </summary>
    public class ContactQuery
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(200)]
        public string Subject { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message is required")]
        [StringLength(5000)]
        public string Message { get; set; } = string.Empty;

        public DateTime SubmittedDate { get; set; } = DateTime.Now;

        [StringLength(5000)]
        public string? Reply { get; set; }

        public DateTime? ReplyDate { get; set; }

        public bool IsResolved { get; set; } = false;

        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
