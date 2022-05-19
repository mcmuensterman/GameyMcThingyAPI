using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameyMcThingy.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameyMcThingy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
            {
            }
        public DbSet<CategoryEntity> Categories {get; set;}
        public DbSet<Game> Games { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }
        public DbSet<UserEntity> Users {get; set;}
        public DbSet<NoteEntity> Notes {get; set;}


    }

}

