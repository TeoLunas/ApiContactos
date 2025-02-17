using ApiContactos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiContactos.Infrastructure
{
    public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext()
        {

        }

        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }
        
        public DbSet<ClientDto> Clients { get; set; }
        public DbSet<CountryDto> Countrys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ClientDto>(entity =>
            {
                entity.HasKey(e => e.ClientID); 
                entity.ToTable("Client");
                entity.Property(e => e.ClientID).HasColumnName("ClientID");
                entity.Property(e => e.FirstName).HasColumnName("firstName").IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(100);
                entity.Property(e => e.Phone).HasColumnName("Phone").IsRequired().HasMaxLength(20);
                entity.Property(e => e.Email).HasColumnName("Email").HasMaxLength(100);
                entity.Property(e => e.CountryID).HasColumnName("CountryID");

                entity.HasOne(e => e.Country)
                      .WithMany() 
                      .HasForeignKey(e => e.CountryID) 
                      .OnDelete(DeleteBehavior.Restrict); 
            });

            modelBuilder.Entity<CountryDto>(entity =>
            {
                entity.HasKey(e => e.CountryID);
                entity.ToTable("Country");
                entity.Property(e => e.CountryID).HasColumnName("CountryID");
                entity.Property(e => e.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);

                entity.HasMany(e => e.Clients) 
                      .WithOne(e => e.Country)
                      .HasForeignKey(e => e.CountryID);
            });

            base.OnModelCreating(modelBuilder);

        }

        partial void ModelCreatingPartial(ModelBuilder modelBuilder);


    }

}
