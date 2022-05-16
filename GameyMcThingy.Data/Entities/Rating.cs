using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameyMcThingy.Data.Entities
{
    public partial class Rating
    {
        public int RatingId { get; set; }
        public int Score { get; set; }
        public int? GameId { get; set; }
        public virtual Game? Game { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }

    }
}
