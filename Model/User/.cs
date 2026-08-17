using System.ComponentModel.DataAnnotations;

namespace GiveAID.Models
{
    /// <summary>
    /// User model represents both Admin and regular User accounts.
    /// Role field determines access: "Admin" or "User".
    /// Password stored as PBKDF2 hash - never plain text.
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(256)]
        public string PasswordHash { get; set; } = string.Empty;

        [StringLength(20)]
        public string? Phone { get; set; }

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = "User";

        [StringLength(100)]
        public string? Profession { get; set; }

        [StringLength(300)]
        public string? Address { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;
    }
}
