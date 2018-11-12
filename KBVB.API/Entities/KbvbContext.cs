using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KBVB.API.Entities
{
    public class KbvbContext : DbContext
    {
        public KbvbContext(DbContextOptions<KbvbContext> options) : base(options)
        {
            Database.EnsureCreated();
           
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.Id);
            modelBuilder.Entity<User>().Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>().Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<User>().HasIndex(u => u.Email)
                .IsUnique();
            modelBuilder.Entity<User>().Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255);

            modelBuilder.Entity<Player>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Player>().Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Player>().Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Player>().Property(u => u.DateOfBirth)
                .IsRequired();
            modelBuilder.Entity<Player>().Property(u => u.CurrentTeam)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Player>().Property(u => u.DidYouKnow)
                .IsRequired()
                .HasMaxLength(255);
            modelBuilder.Entity<Player>().Property(u => u.ImageURL)
                .IsRequired()
                .HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }
    }
}
