using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Weighmast.Models;

namespace Weighmast.Data
{
    public partial class WeighmastContext : DbContext
    {
        public WeighmastContext()
        {
        }

        public WeighmastContext(DbContextOptions<WeighmastContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Driver> Drivers { get; set; } = null!;
        public virtual DbSet<Gate> Gates { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Unit> Units { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Vehicle> Vehicles { get; set; } = null!;
        public virtual DbSet<Weighbridge> Weighbridges { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.AccountCode)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Active).HasColumnType("bit(50)");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.City).HasMaxLength(45);

                entity.Property(e => e.CompanyName).HasMaxLength(50);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(20)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Email)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IsAccount).HasColumnType("bit(50)");

                entity.Property(e => e.IsTransporter).HasColumnType("bit(50)");

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Notes)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(20)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Driver>(entity =>
            {
                entity.ToTable("driver");

                entity.Property(e => e.DriverId).HasColumnName("DriverID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Active).HasColumnType("bit(50)");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IdproofNo)
                    .HasMaxLength(50)
                    .HasColumnName("IDProofNo")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IdproofScan)
                    .HasMaxLength(300)
                    .HasColumnName("IDProofScan")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IdproofType)
                    .HasMaxLength(50)
                    .HasColumnName("IDProofType")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.LastName)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Photo)
                    .HasMaxLength(300)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Gate>(entity =>
            {
                entity.ToTable("gate");

                entity.Property(e => e.GateId).HasColumnName("GateID");

                entity.Property(e => e.Active).HasColumnType("bit(50)");

                entity.Property(e => e.GateName).HasMaxLength(45);

                entity.Property(e => e.GateType).HasColumnType("enum('in','out','both')");

                entity.Property(e => e.Note).HasMaxLength(45);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.IsActive).HasColumnType("bit(50)");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("unit");

                entity.Property(e => e.UnitName)
                    .HasMaxLength(45)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Active).HasColumnType("bit(50)");

                entity.Property(e => e.Address).HasMaxLength(45);

                entity.Property(e => e.ConfirmPassword).HasMaxLength(32);

                entity.Property(e => e.ContactNo).HasMaxLength(45);

                entity.Property(e => e.Email).HasMaxLength(45);

                entity.Property(e => e.FirstName).HasMaxLength(45);

                entity.Property(e => e.LastName).HasMaxLength(45);

                entity.Property(e => e.Notes).HasMaxLength(100);

                entity.Property(e => e.Password).HasMaxLength(32);

                entity.Property(e => e.UserName).HasMaxLength(25);

                entity.Property(e => e.UserRole).HasColumnType("enum('Admin','User')");
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("vehicle");

                entity.Property(e => e.VehicleId)
                    .ValueGeneratedNever()
                    .HasColumnName("VehicleID");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.IsActive).HasColumnType("bit(50)");

                entity.Property(e => e.Notes)
                    .HasMaxLength(1000)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TareWeight).HasPrecision(18, 4);

                entity.Property(e => e.VehicleNumber)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Weighbridge>(entity =>
            {
                entity.ToTable("weighbridge");

                entity.Property(e => e.ConnectionType).HasColumnType("enum('COM','LAN')");

                entity.Property(e => e.DataBits)
                    .HasColumnType("enum('7','8')")
                    .HasColumnName("DataBIts");

                entity.Property(e => e.Format).HasMaxLength(45);
                modelBuilder.Entity<Weighbridge>()
    .Property(e => e.ConnectionType)
    .HasMaxLength(50); // Adjust the length as needed

                entity.Property(e => e.Handshake)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.IndicatorId).HasColumnName("IndicatorID");

                entity.Property(e => e.IsActive).HasColumnType("bit(50)");

                entity.Property(e => e.IsDecimalCharacterInString).HasMaxLength(45);

                entity.Property(e => e.MaxCapacity)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Parity).HasMaxLength(45);

                entity.Property(e => e.ReverseString).HasMaxLength(45);

                entity.Property(e => e.ScaleName)
                    .HasMaxLength(250)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.SerialPort).HasMaxLength(45);

                entity.Property(e => e.StartStringCharacter).HasMaxLength(45);

                entity.Property(e => e.Unit).HasMaxLength(45);

                entity.Property(e => e.WeightLength)
                    .HasMaxLength(45)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.WeightStartFrom)
                    .HasMaxLength(45)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
