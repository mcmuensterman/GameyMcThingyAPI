using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameyMcThingy.Data.Entities
{
    public partial class Game
    {
        public Game()
        {
            Categories = new HashSet<Category>();
            Ratings = new HashSet<Rating>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Manufacturer { get; set; }
        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
