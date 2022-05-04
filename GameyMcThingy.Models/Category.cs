using System;
using System.Collections.Generic;

namespace GameyMcThingy.WebAPI
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public int? GameId { get; set; }
        public string? GameCategory { get; set; }

        public virtual Game? Game { get; set; }
    }
}
