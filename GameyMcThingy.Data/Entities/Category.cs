using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameyMcThingy.Data.Entities
{
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [ForeignKey("Game")]
        public int GameId { get; set; }
        [Required]
        public string GameCategory { get; set; }
        [Required]
        public virtual Game Game { get; set; }
        public List<Game> Games { get; set; }
    }
}
