using System;

namespace GameyMcThingy.Models.Rating
{
    public class RatingListItem
    {
        public int RatingId { get; set; }
        public int GameId { get; set; }
        public int Score { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
