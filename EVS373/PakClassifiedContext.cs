using EVS373.PakClassified;
using EVS373.UsersMgt;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EVS373
{
    public class PakClassifiedContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdvertizementStatus> AdvertizementStatus { get; set; }
        public DbSet<AdvertizementType> AdvertizementTypes { get; set; }
        public DbSet<AdvertizementCategory> AdvertizementCategories { get; set; }
        public DbSet<Advertizement> Advertizements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //code here

            //1 to 1
            modelBuilder.Entity<User>()
                .HasOne<Address>(u => u.Address)
                .WithOne()
                .HasForeignKey<Address>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //One to Manay
            modelBuilder.Entity<Advertizement>()
                .HasMany<AdvertizementImage>(a => a.Images)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            //One to Manay
            modelBuilder.Entity<Advertizement>()
                .HasOne<AdvertizementStatus>(a => a.Status)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);





        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //code here
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-0JN5F0M9\\MSSQLSERVERR;user id=sa;password=123;Initial Catalog=PakClassified373");

        }






    }
}
