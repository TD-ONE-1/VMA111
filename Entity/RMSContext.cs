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

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<EventQuery> EventQueries { get; set; }

    public virtual DbSet<OrdersListing> OrdersListings { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PackageService> PackageServices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductListing> ProductListings { get; set; }

    public virtual DbSet<R_BookingType> R_BookingTypes { get; set; }

    public virtual DbSet<R_Branch> R_Branches { get; set; }

    public virtual DbSet<R_Event> R_Events { get; set; }

    public virtual DbSet<R_Image> R_Images { get; set; }

    public virtual DbSet<R_Menu> R_Menus { get; set; }

    public virtual DbSet<R_Offer> R_Offers { get; set; }

    public virtual DbSet<R_Slot> R_Slots { get; set; }

    public virtual DbSet<ReservationRequest> ReservationRequests { get; set; }

    public virtual DbSet<ReservationRequestDetail> ReservationRequestDetails { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<ServiceMaster> ServiceMasters { get; set; }

    public virtual DbSet<Shopkeeper> Shopkeepers { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<tblAuthentication> tblAuthentications { get; set; }

    public virtual DbSet<vwEventQuery> vwEventQueries { get; set; }

    public virtual DbSet<vwReservation> vwReservations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RMS;Data Source=IT-DHP-2300718\\MSSQLSERVER01; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64D86724D10B");

            entity.ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.CNIC)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.CustAccountCode)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.CustName).HasMaxLength(100);
            entity.Property(e => e.CustomerCode).HasMaxLength(50);
            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.NTN)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<EventQuery>(entity =>
        {
            entity.ToTable("EventQuery");

            entity.Property(e => e.BookingDate).HasColumnType("datetime");
            entity.Property(e => e.CellNumber).HasMaxLength(50);
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EnquiryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<OrdersListing>(entity =>
        {
            entity.HasKey(e => e.OLId).HasName("PK__OrdersLi__AF348F78E0E7F3DB");

            entity.Property(e => e.CategoryType).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.OrderAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.PkgName).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<PackageService>(entity =>
        {
            entity.ToTable("PackageService");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6CDB5715087");

            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasDefaultValue("");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasDefaultValue("");
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.TDDiscount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxAppilcable).HasDefaultValue(true);
        });

        modelBuilder.Entity<ProductListing>(entity =>
        {
            entity.HasKey(e => e.PLId).HasName("PK__ProductL__5ED8B9ABEABABB43");

            entity.ToTable("ProductListing");

            entity.Property(e => e.CategoryType).HasMaxLength(100);
            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status).HasDefaultValue(true);
        });

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

            entity.Property(e => e.Address).IsUnicode(false);
            entity.Property(e => e.Email).IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber).IsUnicode(false);
        });

        modelBuilder.Entity<R_Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<R_Image>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__R_Images__3214EC07A48391A7");

            entity.Property(e => e.CreatedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImagePath).HasMaxLength(300);
            entity.Property(e => e.ImageType)
                .HasMaxLength(20)
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
        });

        modelBuilder.Entity<R_Offer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Restaura__3214EC07F22961E3");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Offer)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Branch).WithMany(p => p.R_Offers)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_R_Offers_R_Branches");
        });

        modelBuilder.Entity<R_Slot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__R_Slots");

            entity.Property(e => e.BreakDuration).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Day)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Duration).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ReservationRequest>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reservat__3214EC078928C7A6");

            entity.ToTable("ReservationRequest");

            entity.Property(e => e.PhoneNo)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Remarks).HasDefaultValue("");
            entity.Property(e => e.ReservationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ReservationName)
                .HasMaxLength(50)
                .HasDefaultValue("");

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

            entity.Property(e => e.About_Description).HasDefaultValue("");
            entity.Property(e => e.CuisineType).HasDefaultValue("");
            entity.Property(e => e.Name).HasDefaultValue("");
            entity.Property(e => e.PriceRange).HasDefaultValue("");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Reviews");

            entity.Property(e => e.Remarks)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ServiceMaster>(entity =>
        {
            entity.ToTable("ServiceMaster");

            entity.Property(e => e.ServiceName).HasMaxLength(50);
        });

        modelBuilder.Entity<Shopkeeper>(entity =>
        {
            entity.HasKey(e => e.ShopkeeperId).HasName("PK__Shopkeep__84FE8E2D620DFDDC");

            entity.ToTable("Shopkeeper");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.BusinessName)
                .HasMaxLength(150)
                .HasDefaultValue("");
            entity.Property(e => e.CNIC)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.NTN)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.ShopkeeperName).HasMaxLength(100);
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.Website)
                .HasMaxLength(100)
                .HasDefaultValue("");
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

            entity.HasOne(d => d.UserType).WithMany(p => p.tblAuthentications)
                .HasForeignKey(d => d.UserTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblAuthentication_UserTypes");
        });

        modelBuilder.Entity<vwEventQuery>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEventQueries");

            entity.Property(e => e.CellNumber).HasMaxLength(50);
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EventType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ServiceName).HasMaxLength(50);
            entity.Property(e => e.Timing)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<vwReservation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwReservation");

            entity.Property(e => e.BookingType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.BranchName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Offer)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.ReservationName).HasMaxLength(50);
            entity.Property(e => e.Slot)
                .HasMaxLength(13)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
