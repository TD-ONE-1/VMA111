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

    public virtual DbSet<EidReservation> EidReservations { get; set; }

    public virtual DbSet<EventQuery> EventQueries { get; set; }

    public virtual DbSet<MealType> MealTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Package> Packages { get; set; }

    public virtual DbSet<PackageService> PackageServices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductPurchase> ProductPurchases { get; set; }

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

    public virtual DbSet<ShopBranch> ShopBranches { get; set; }

    public virtual DbSet<Shopkeeper> Shopkeepers { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<tblAuthentication> tblAuthentications { get; set; }

    public virtual DbSet<vwEidReservation> vwEidReservations { get; set; }

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

        modelBuilder.Entity<EidReservation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SpecialRequest");

            entity.ToTable("EidReservation");

            entity.Property(e => e.Name).HasDefaultValue("");
            entity.Property(e => e.Phone)
                .HasMaxLength(30)
                .HasDefaultValue("");

            entity.HasOne(d => d.BookingType).WithMany(p => p.EidReservations)
                .HasForeignKey(d => d.BookingTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpecialRequest_R_BookingType");

            entity.HasOne(d => d.MealType).WithMany(p => p.EidReservations)
                .HasForeignKey(d => d.MealTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EidReservation_MealType");

            entity.HasOne(d => d.Slot).WithMany(p => p.EidReservations)
                .HasForeignKey(d => d.SlotId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SpecialRequest_R_Slots");
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

        modelBuilder.Entity<MealType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MealType");

            entity.ToTable("MealType");

            entity.Property(e => e.MealTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BCFFE47DB49");

            entity.Property(e => e.ConfirmDeliveryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ContactPerson)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.DeliveryReceivedBy)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Discount).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.ExpectedDeliveryDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.OrderStatus).HasMaxLength(50);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TaxPercentage).HasColumnType("decimal(5, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Customer");

            entity.HasOne(d => d.Product).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_Products");

            entity.HasOne(d => d.Shopkeeper).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ShopkeeperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_ShopBranch");
        });

        modelBuilder.Entity<Package>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.PkgName)
                .HasMaxLength(50)
                .HasDefaultValue("");
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

            entity.HasOne(d => d.Branch).WithMany(p => p.Products)
                .HasForeignKey(d => d.BranchId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ShopBranch");

            entity.HasOne(d => d.CategoryType).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ProductCategory");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductCategory");

            entity.ToTable("ProductCategory");

            entity.Property(e => e.CategoryType).HasMaxLength(200);
        });

        modelBuilder.Entity<ProductPurchase>(entity =>
        {
            entity.HasKey(e => e.ProductPurchaseId).HasName("PK__ProductP__910433C8593E7698");

            entity.ToTable("ProductPurchase");

            entity.Property(e => e.PODate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PONumber)
                .HasMaxLength(50)
                .HasDefaultValue("");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .HasDefaultValue("");

            entity.HasOne(d => d.Shopkeeper).WithMany(p => p.ProductPurchases)
                .HasForeignKey(d => d.ShopkeeperId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductPurchase_Shopkeeper");
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

        modelBuilder.Entity<ShopBranch>(entity =>
        {
            entity.HasKey(e => e.BranchID).HasName("PK__ShopBran__A1682FA575A21290");

            entity.ToTable("ShopBranch");

            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasDefaultValue("");
            entity.Property(e => e.BranchName).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasDefaultValue("");
            entity.Property(e => e.Latitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitude).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .HasDefaultValue("");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(20)
                .HasDefaultValue("");
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

        modelBuilder.Entity<vwEidReservation>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwEidReservation");

            entity.Property(e => e.BookingType)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MealTypeName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Slot)
                .HasMaxLength(13)
                .IsUnicode(false);
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
