using System.ComponentModel.DataAnnotations;

namespace GameyMcThingy.Data.Entities
{
    public class GameEntity
    {
        [Key]
        public int Id { get; set; }
        // !Not sure if below line is needed or not
        // [Required]
        // public int OwnerId { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [Required]

        public string? Manufacturer { get; set; }
    }
}