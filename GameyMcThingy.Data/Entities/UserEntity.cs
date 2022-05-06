using System;
using System.Collections.Generic;

namespace GameyMcThingy.Data.Entities
{
    public partial class UserEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? DateCreated { get; set; }
    }
}

