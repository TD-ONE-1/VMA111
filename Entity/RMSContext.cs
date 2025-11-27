using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RMS.Entity;

public partial class RMSContext : DbContext
{
    public RMSContext()
    {
    }

    public RMSContext(DbContextOptions<RMSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<R_BookingType> R_BookingTypes { get; set; }

    public virtual DbSet<R_Branch> R_Branches { get; set; }

    public virtual DbSet<R_Event> R_Events { get; set; }

    public virtual DbSet<R_Menu> R_Menus { get; set; }

    public virtual DbSet<R_Offer> R_Offers { get; set; }

    public virtual DbSet<R_Slot> R_Slots { get; set; }

    public virtual DbSet<ReservationRequest> ReservationRequests { get; set; }

    public virtual DbSet<ReservationRequestDetail> ReservationRequestDetails { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<SignUpUser> SignUpUsers { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<tblAuthentication> tblAuthentications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RMS;Data Source=IT-DHP-2300718\\MSSQLSERVER01; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<R_BookingType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BookingType");

            entity.ToTable("R_BookingType");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<R_Branch>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RestaurantBranches");

            entity.Property(e => e.Location).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<R_Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<R_Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__R_Menu");

            entity.ToTable("R_Menu");

            entity.Property(e => e.ItemDetail).IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Offer).WithMany(p => p.R_Menus)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_R_Menu_R_Offers");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.R_Menus)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_R_Menu_Restaurant");
        });

        modelBuilder.Entity<R_Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Restaura__3214EC07F22961E3");

            entity.Property(e => e.EndDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.EndTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Offer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StartDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.StartTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Branch).WithMany(p => p.R_Offers)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_R_Offers_R_Branches");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.R_Offers)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_R_Offers_Restaurant");
        });

        modelBuilder.Entity<R_Slot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__R_Slots");
        });

        modelBuilder.Entity<ReservationRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC078928C7A6");

            entity.ToTable("ReservationRequest");

            entity.Property(e => e.Remarks).HasDefaultValue("");
            entity.Property(e => e.ReservationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.BookingType).WithMany(p => p.ReservationRequests)
                .HasForeignKey(d => d.BookingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationMaster_R_BookingType");

            entity.HasOne(d => d.Branch).WithMany(p => p.ReservationRequests)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationMaster_R_Branches");

            entity.HasOne(d => d.Offer).WithMany(p => p.ReservationRequests)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationMaster_R_Offers");

            entity.HasOne(d => d.Restaurant).WithMany(p => p.ReservationRequests)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationMaster_Restaurant");

            entity.HasOne(d => d.Slot).WithMany(p => p.ReservationRequests)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ReservationMaster_R_Slots");
        });

        modelBuilder.Entity<ReservationRequestDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC07E561D4AD");

            entity.ToTable("ReservationRequestDetail");

            entity.Property(e => e.ConfirmedBy).HasDefaultValue("");
            entity.Property(e => e.ConfirmedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Resturant");

            entity.ToTable("Restaurant");

            entity.Property(e => e.ClosingTime).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Location).HasDefaultValue("");
            entity.Property(e => e.Name).HasDefaultValue("");
            entity.Property(e => e.OpeningTime).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews");

            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SignUpUser>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(500);
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserTypes");

            entity.Property(e => e.UserTypes)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblAuthentication>(entity =>
        {
            entity.ToTable("tblAuthentication");

            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.UserCode).HasMaxLength(20);

            entity.HasOne(d => d.User).WithMany(p => p.tblAuthentications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAuthentication_SignUpUsers");

            entity.HasOne(d => d.UserType).WithMany(p => p.tblAuthentications)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAuthentication_UserTypes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
