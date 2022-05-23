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
        [MinLength(2, ErrorMessage = "Category Name needs at least {1} characters.")]
        [MaxLength(30, ErrorMessage ="Category Name cannot be more than {1} characters.")]
        public string GameCategory { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage ="Description cannot be more than {1} characters.")]
        public string CategoryDescriptor { get; set; }
    }
}