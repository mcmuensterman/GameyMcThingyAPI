using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameyMcThingy.Data.Entities
{
    public class ReviewEntity
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; } = null!;
        public string ReviewComment { get; set; } = null!;
        public int GameId { get; set; }
 
        public virtual GameEntity Game { get; set; }
    }
}
