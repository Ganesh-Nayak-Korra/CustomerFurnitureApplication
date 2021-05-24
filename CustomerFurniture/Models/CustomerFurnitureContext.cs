using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CustomerFurnitureApplication.Models
{
    public partial class CustomerFurnitureContext : DbContext
    {
        public CustomerFurnitureContext()
        {
        }

        public CustomerFurnitureContext(DbContextOptions<CustomerFurnitureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerFurniture> CustomerFurnitures { get; set; }
        public virtual DbSet<Furniture> Furnitures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; Database=CustomerFurniture;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.HasIndex(e => e.PhoneNumber, "UQ__Customer__85FB4E3841CF88C0")
                    .IsUnique();

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(60);

                entity.Property(e => e.Name).HasMaxLength(40);
            });

            modelBuilder.Entity<CustomerFurniture>(entity =>
            {
                entity.HasKey(e => e.Cfid)
                    .HasName("PK__Customer__F54E0D3CCD226876");

                entity.ToTable("CustomerFurniture");

                entity.Property(e => e.Cfid)
                    .ValueGeneratedNever()
                    .HasColumnName("CFId");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerFurnitures)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__CustomerF__Custo__286302EC");

                entity.HasOne(d => d.Furniture)
                    .WithMany(p => p.CustomerFurnitures)
                    .HasForeignKey(d => d.FurnitureId)
                    .HasConstraintName("FK__CustomerF__Furni__29572725");
            });

            modelBuilder.Entity<Furniture>(entity =>
            {
                entity.ToTable("Furniture");

                entity.Property(e => e.FurnitureId).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Title).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
