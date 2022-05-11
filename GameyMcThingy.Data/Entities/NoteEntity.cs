using System;
using System.ComponentModel.DataAnnotations;

namespace GameyMcThingy.Data.Entities
{
    public class NoteEntity
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public int OwnerId {get; set;}
        [Required]
        public string Title {get; set;}
        [Required]
        public string Content {get; set;}
        public DateTimeOffset CreatedUtc {get; set;}
        public DateTimeOffset? ModifiedUtc {get; set;}
    }
}