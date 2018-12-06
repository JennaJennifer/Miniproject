using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MinReceptbok.Models.Entities
{
    public partial class ReceptDBContext : DbContext
    {
        public ReceptDBContext()
        {
        }

        public ReceptDBContext(DbContextOptions<ReceptDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Receptbank> Receptbank { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ReceptDB;Integrated Security=True;Connect Timeout=10;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receptbank>(entity =>
            {
                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Recept)
                    .HasMaxLength(4000)
                    .IsUnicode(false);
            });
        }
    }
}
