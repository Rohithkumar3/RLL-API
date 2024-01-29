using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace onlinebus.Models
{
    public partial class onlinebookingContext : DbContext
    {
        public onlinebookingContext()
        {
        }

        public onlinebookingContext(DbContextOptions<onlinebookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adminlogin> Adminlogins { get; set; } = null!;
        public virtual DbSet<BusInventory> BusInventories { get; set; } = null!;
        public virtual DbSet<Usersignup> Usersignups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=LAPTOP-CL65602K\\SQLEXPRESS;database=onlinebooking;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adminlogin>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__adminlog__C9F284573D56E6D9");

                entity.ToTable("adminlogin");

                entity.Property(e => e.UserName)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(90)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BusInventory>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__BusInven__73951AEDCB1BBF61");

                entity.ToTable("BusInventory");

                entity.Property(e => e.AvailabilitySeats).HasColumnName("Availability_Seats");

                entity.Property(e => e.Boarding).HasMaxLength(50);

                entity.Property(e => e.BusCategory).HasMaxLength(10);

                entity.Property(e => e.BusName).HasMaxLength(15);

                entity.Property(e => e.Departure).HasMaxLength(50);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Usersignup>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__usersign__F3DBC573DCE97B14");

                entity.ToTable("usersignup");

                entity.Property(e => e.Username)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Address)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
