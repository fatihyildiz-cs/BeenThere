using System;
using BeenThere1.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BeenThere1.Data.Concrete
{    
    public class BTContext : IdentityDbContext<BeenThereUser>

    {

        public BTContext(DbContextOptions<BTContext> options)

            : base(options)

        {

        }

        public BTContext()
        {

        }



        public DbSet<Experience> Experiences { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<CountryList> CountryLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=localhost;Database=BeenThereDB1;User Id=sa;Password=myPassw0rd;MultipleActiveResultSets=true");

            optionsBuilder.EnableSensitiveDataLogging();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LocationCategoryJunction>()
                .HasKey(t => new { t.LocationId, t.CategoryId });

            modelBuilder.Entity<LocationCategoryJunction>()
                .HasOne(j => j.Location)
                .WithMany(l => l.LocationCategoryJunctions)
                .HasForeignKey(j => j.LocationId);

            modelBuilder.Entity<LocationCategoryJunction>()
                .HasOne(j => j.Category)
                .WithMany(c => c.LocationCategoryJunctions)
                .HasForeignKey(j => j.CategoryId);

            modelBuilder.Entity<ExperienceCategoryJunction>()
                .HasKey(t => new { t.ExperienceId, t.CategoryId });

            modelBuilder.Entity<ExperienceCategoryJunction>()
                .HasOne(j => j.Experience)
                .WithMany(e => e.ExperienceCategoryJunctions)
                .HasForeignKey(j => j.ExperienceId);

            modelBuilder.Entity<ExperienceCategoryJunction>()
                .HasOne(j => j.Category)
                .WithMany(c => c.ExperienceCategoryJunctions)
                .HasForeignKey(j => j.CategoryId);
        }

    }

    
}
