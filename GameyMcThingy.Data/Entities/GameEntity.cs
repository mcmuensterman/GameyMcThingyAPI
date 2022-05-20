using System.ComponentModel.DataAnnotations;

namespace GameyMcThingy.Data.Entities
{
    public class GameEntity
    {
        public GameEntity()
        {
            // Categories = new HashSet<Category>();
            // Ratings = new HashSet<Rating>();
            // Reviews = new HashSet<Review>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Manufacturer { get; set; }
        public int OwnerId { get; set; }

        // public virtual ICollection<Category> Categories { get; set; }
        // public virtual ICollection<Rating> Ratings { get; set; }
        // public virtual ICollection<Review> Reviews { get; set; }
    }

}