using System.ComponentModel.DataAnnotations;

namespace GameyMcThingy.Models.Game
{
    public class GameCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} ,must be at least {1} characers long.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Title { get; set; } = null!;
        [Required]
        [MinLength(2, ErrorMessage = "{0} ,must be at least {1} characers long.")]
        [MaxLength(100, ErrorMessage = "{0} must contain no more than {1} characters.")]
        public string Manufacturer { get; set; }
    }
}