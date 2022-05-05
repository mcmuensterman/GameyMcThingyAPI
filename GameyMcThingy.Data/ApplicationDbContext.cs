using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameyMcThingy.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Game> Games { get; set; } = null!;
        public virtual DbSet<Rating> Ratings { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<UserEntity> UserEntities { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:GameyMcThingy");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.GameCategory).HasMaxLength(50);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Categorie__GameI__4E88ABD4");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Manufacturer).HasMaxLength(50);

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Ratings)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Ratings__GameId__5165187F");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.ReviewComment).HasMaxLength(300);

                entity.Property(e => e.ReviewTitle).HasMaxLength(50);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__Reviews__GameId__5441852A");
            });

            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.ToTable("UserEntity");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(26);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

