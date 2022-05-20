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
        public DbSet<GameEntity> Games { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        // Game Entity 14.01 ZM 
        public DbSet<GameEntity> GameEntities { get; set; }
    }
}

