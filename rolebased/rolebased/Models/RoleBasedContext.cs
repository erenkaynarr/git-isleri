using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace rolebased.Models
{
    public partial class RoleBasedContext : DbContext
    {
        public RoleBasedContext()
        {
        }

        public RoleBasedContext(DbContextOptions<RoleBasedContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Food> Foods { get; set; } = null!;
        public virtual DbSet<Personel> Personels { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("server=localhost;Database=RoleBased;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                

                entity.ToTable("customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("customerID");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("customerName");

                entity.Property(e => e.CustomerSurname)
                    .HasMaxLength(50)
                    .HasColumnName("customerSurname");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                

                entity.ToTable("department");

                entity.Property(e => e.DepartmantName)
                    .HasMaxLength(50)
                    .HasColumnName("departmantName");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<Food>(entity =>
            {
                

                entity.ToTable("food");

                entity.Property(e => e.FoodId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("foodID");

                entity.Property(e => e.FoodName)
                    .HasMaxLength(50)
                    .HasColumnName("foodName");

                entity.Property(e => e.FoodPrice).HasColumnName("foodPrice");
            });

            modelBuilder.Entity<Personel>(entity =>
            {
                

                entity.ToTable("personel");

                entity.Property(e => e.PersonelId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("personelID");

                entity.Property(e => e.PersonelName)
                    .HasMaxLength(50)
                    .HasColumnName("personelName");

                entity.Property(e => e.PersonelSurname)
                    .HasMaxLength(50)
                    .HasColumnName("personelSurname");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
