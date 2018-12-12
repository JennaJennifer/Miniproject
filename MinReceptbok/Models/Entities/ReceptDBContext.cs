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

        public virtual DbSet<Images> Images { get; set; }
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
            modelBuilder.Entity<Images>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ImageRef)
                    .IsRequired()
                    .HasMaxLength(4000);

                entity.HasOne(d => d.R)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Images__Rid__36B12243");
            });

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
