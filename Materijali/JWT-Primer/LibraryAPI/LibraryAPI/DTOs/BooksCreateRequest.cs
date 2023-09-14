

using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.DTOs
{
    public class BooksCreateRequest
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Author { get; set; }
    }
}
