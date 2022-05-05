<<<<<<< HEAD
﻿using System;
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
=======
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameyMcThingy.Data.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

    }
}
>>>>>>> e8e021a2fd29c35446488b4fa93419fd9fe494da
