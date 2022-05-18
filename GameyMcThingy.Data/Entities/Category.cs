using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GameyMcThingy.Data.Entities
{
    public partial class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public int GameId { get; set; }
        [Required]
        public string GameCategory { get; set; }
        [Required]
        public virtual Game Game { get; set; }
        public List<Game> Games { get; set; }
    }
}
