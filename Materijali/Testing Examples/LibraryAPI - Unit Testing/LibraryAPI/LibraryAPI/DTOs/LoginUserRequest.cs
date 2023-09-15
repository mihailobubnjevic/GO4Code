using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOs
{
    public class LoginUserRequest
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
