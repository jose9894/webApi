using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MenuApiV2.Models;

namespace MenuApiV2.Data;

public partial class FoodAppDbContext : DbContext
{
    public FoodAppDbContext()
    {
    }

    public FoodAppDbContext(DbContextOptions<FoodAppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cook> Cooks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DeliveryCyclist> DeliveryCyclists { get; set; }

    public virtual DbSet<Meal> Meals { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Trip> Trips { get; set; }

    public virtual DbSet<TripDetail> TripDetails { get; set; }

    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //     => optionsBuilder.UseSqlServer("Server=localhost;Database=foodAppDb;User Id=sa;Password=Fhe73chv#;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cook>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__Cook__A9FDEC127251B792");

            entity.ToTable("Cook");

            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.PhoneNr).HasMaxLength(15);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__Customer__A9FDEC12938DD7D0");

            entity.ToTable("Customer");

            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.PaymentOpt).HasMaxLength(50);
            entity.Property(e => e.PhoneNr).HasMaxLength(15);
        });

        modelBuilder.Entity<DeliveryCyclist>(entity =>
        {
            entity.HasKey(e => e.DcId).HasName("PK__Delivery__46564CF923AA2834");

            entity.ToTable("Delivery_Cyclist");

            entity.Property(e => e.DcId).HasColumnName("DC_ID");
            entity.Property(e => e.BikeType).HasMaxLength(50);
            entity.Property(e => e.PhoneNr).HasMaxLength(15);
        });

        modelBuilder.Entity<Meal>(entity =>
        {
            entity.HasKey(e => e.MId).HasName("PK__Meal__18B1A3178C6A276D");

            entity.ToTable("Meal");

            entity.Property(e => e.MId).HasColumnName("M_ID");
            entity.Property(e => e.CookId).HasColumnName("CookID");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Qty).HasColumnName("QTY");

            entity.HasOne(d => d.Cook).WithMany(p => p.Meals)
                .HasForeignKey(d => d.CookId)
                .HasConstraintName("FK__Meal__CookID__753864A1");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("PK__Order__5AAB0C183571FF88");

            entity.ToTable("Order");

            entity.Property(e => e.OId).HasColumnName("O_ID");
            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.ODate)
                .HasColumnType("datetime")
                .HasColumnName("O_DATE");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK__Order__C_ID__7DCDAAA2");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OId, e.MId }).HasName("PK__Order_De__3B201629AE535250");

            entity.ToTable("Order_Details");

            entity.Property(e => e.OId).HasColumnName("O_ID");
            entity.Property(e => e.MId).HasColumnName("M_ID");
            entity.Property(e => e.Qty).HasColumnName("QTY");

            entity.HasOne(d => d.MIdNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.MId)
                .HasConstraintName("FK__Order_Deta__M_ID__019E3B86");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OId)
                .HasConstraintName("FK__Order_Deta__O_ID__00AA174D");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK__Rating__DE152E8970A20A71");

            entity.ToTable("Rating");

            entity.Property(e => e.RId).HasColumnName("R_ID");
            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.CStars).HasColumnName("C_STARS");
            entity.Property(e => e.CookId).HasColumnName("CookID");
            entity.Property(e => e.DcId).HasColumnName("DC_ID");
            entity.Property(e => e.DcStars).HasColumnName("DC_STARS");
            entity.Property(e => e.OId).HasColumnName("O_ID");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK__Rating__C_ID__0EF836A4");

            entity.HasOne(d => d.Cook).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.CookId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Rating__CookID__0E04126B");

            entity.HasOne(d => d.Dc).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.DcId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Rating__DC_ID__0FEC5ADD");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.OId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rating__O_ID__10E07F16");
        });

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(e => e.TId).HasName("PK__Trip__83BB1FB2666AB6D8");

            entity.ToTable("Trip");

            entity.Property(e => e.TId).HasColumnName("T_ID");
            entity.Property(e => e.DcId).HasColumnName("DC_ID");
            entity.Property(e => e.OId).HasColumnName("O_ID");
            entity.Property(e => e.TTime).HasColumnName("T_Time");

            entity.HasOne(d => d.Dc).WithMany(p => p.Trips)
                .HasForeignKey(d => d.DcId)
                .HasConstraintName("FK__Trip__DC_ID__056ECC6A");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.Trips)
                .HasForeignKey(d => d.OId)
                .HasConstraintName("FK__Trip__O_ID__047AA831");
        });

        modelBuilder.Entity<TripDetail>(entity =>
        {
            entity.HasKey(e => new { e.TId, e.TimeStamp }).HasName("PK__Trip_Det__3881C38E1EBAD5DF");

            entity.ToTable("Trip_Details");

            entity.Property(e => e.TId).HasColumnName("T_ID");
            entity.Property(e => e.TimeStamp).HasColumnName("Time_Stamp");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.TripType).HasMaxLength(50);

            entity.HasOne(d => d.TIdNavigation).WithMany(p => p.TripDetails)
                .HasForeignKey(d => d.TId)
                .HasConstraintName("FK__Trip_Detai__T_ID__084B3915");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
