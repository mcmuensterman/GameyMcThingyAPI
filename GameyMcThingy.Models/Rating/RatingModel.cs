using System;

namespace GameyMcThingy.Models.Rating
{
    public class RatingModel
    {
        
        public int GameId { get; set; }
        public int Score { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
    }
}