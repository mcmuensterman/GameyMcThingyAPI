using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameyMcThingy.Data.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryId { get; set; }

        // [ForeignKey("Game")]
        // public int GameId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Category Name cannot be more than {1} characters.")]
        public string GameCategory { get; set; }

        [MaxLength(200, ErrorMessage = "Description cannot be more than {1} characters.")]
        public string CategoryDescriptor { get; set; }

        [Required]
        public virtual ICollection<GameEntity> Games { get; set; } = new List<GameEntity>();
        
        // public List<GameEntity> Games { get; set; }
    }
}
