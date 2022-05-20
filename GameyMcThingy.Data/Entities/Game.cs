using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameyMcThingy.Data.Entities
{
    public class Game
    {
        public Game()
        {
            Categories = new HashSet<CategoryEntity>();
            Ratings = new HashSet<Rating>();
            Reviews = new HashSet<ReviewEntity>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Manufacturer { get; set; }
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }

        public virtual ICollection<CategoryEntity> Categories { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<ReviewEntity> Reviews { get; set; }
    }
}
