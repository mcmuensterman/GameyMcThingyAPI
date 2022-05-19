using System;
using System.Collections.Generic;

namespace GameyMcThingy.Data.Entities
{
    public class Game
    {
        public Game()
        {
            Categories = new HashSet<Category>();
            Ratings = new HashSet<RatingEntity>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Manufacturer { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<RatingEntity> Ratings { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
