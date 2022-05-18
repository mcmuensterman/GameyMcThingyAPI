using System;
using System.Collections.Generic;

namespace GameyMcThingy.Data.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Score { get; set; }
        public int? GameId { get; set; }

        public virtual Game? Game { get; set; }
    }
}
