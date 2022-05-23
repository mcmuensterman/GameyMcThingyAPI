using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameyMcThingy.Data.Entities
{
    public class RatingEntity
    {
        [Key]
        public int RatingId { get; set; }
        public int Score { get; set; }
        public int GameId { get; set; }
        public virtual GameEntity Game { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }

        [ForeignKey(nameof(Owner))]
        public int OwnerId { get; set; }
        public UserEntity Owner { get; set; }

    }
}
