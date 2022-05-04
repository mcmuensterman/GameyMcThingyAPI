using System;
using System.Collections.Generic;

namespace GameyMcThingy.WebAPI
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int Score { get; set; }
        public int? GameId { get; set; }

        public virtual Game? Game { get; set; }
    }
}
