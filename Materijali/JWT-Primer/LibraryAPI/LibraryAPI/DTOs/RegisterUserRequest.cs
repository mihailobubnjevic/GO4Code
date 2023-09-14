using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOs
{
    public class RegisterUserRequest
    {
        [Required]
        public string? Username { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
