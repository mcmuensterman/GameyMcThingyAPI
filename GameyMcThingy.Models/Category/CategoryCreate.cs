using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameyMcThingy.Models.Category
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "{0} must be at least {1} characters long.")]
        [MaxLength(30, ErrorMessage ="{0} must be no more than {1} characters.")]
        public string GameCategory { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage ="{0} must be no more than {1} characters.")]
        public string CategoryDescriptor { get; set; }
    }
}