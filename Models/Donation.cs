using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiveAID.Models
{
    /// <summary>
    /// Donation records each financial contribution.
    /// Only last 4 digits of card stored for PCI compliance.
    /// Unique TransactionId generated for each donation.
    /// </summary>
    public class Donation
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int DonationCauseId { get; set; }

        [Required]
        [Range(1, 10000000, ErrorMessage = "Amount must be between 1 and 10,000,000")]
        public decimal Amount { get; set; }

        [StringLength(4)]
        public string? CardLastFour { get; set; }

        [Required]
        [StringLength(10)]
        public string CardType { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string CardHolderName { get; set; } = string.Empty;

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string? TransactionId { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [ForeignKey("DonationCauseId")]
        public DonationCause? DonationCause { get; set; }
    }
}
