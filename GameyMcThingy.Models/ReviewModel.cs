namespace GameyMcThingy.Models
{
    public class ReviewModel
    {
        public int ReviewId { get; set; }
        public string ReviewTitle { get; set; } = null!;
        public string ReviewComment { get; set; } = null!;
        public int GameId { get; set; }
    }
}