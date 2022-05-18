using System;
using System.Collections.Generic;

namespace GameyMcThingy.Data.Entities
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; } = null!;
        public string ReviewComment { get; set; } = null!;
        public int? GameId { get; set; }

        public virtual Game? Game { get; set; }
    }
}
