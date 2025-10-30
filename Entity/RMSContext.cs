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

    public virtual DbSet<Resturant> Resturants { get; set; }

    public virtual DbSet<ResturantConfigration> ResturantConfigrations { get; set; }

    public virtual DbSet<ResturantOffer> ResturantOffers { get; set; }

    public virtual DbSet<ResturantVenue> ResturantVenues { get; set; }

    public virtual DbSet<SignUpUser> SignUpUsers { get; set; }

    public virtual DbSet<tblAuthentication> tblAuthentications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RMS;Data Source=IT-DHP-2300718\\MSSQLSERVER01; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resturant>(entity =>
        {
            entity.ToTable("Resturant");
        });

        modelBuilder.Entity<ResturantConfigration>(entity =>
        {
            entity.ToTable("ResturantConfigration");

            entity.Property(e => e.From).HasColumnType("datetime");
            entity.Property(e => e.To).HasColumnType("datetime");

            entity.HasOne(d => d.Offer).WithMany(p => p.ResturantConfigrations)
                .HasForeignKey(d => d.OfferId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResturantConfigration_ResturantOffer");

            entity.HasOne(d => d.Resturant).WithMany(p => p.ResturantConfigrations)
                .HasForeignKey(d => d.ResturantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResturantConfigration_Resturant");

            entity.HasOne(d => d.Venue).WithMany(p => p.ResturantConfigrations)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResturantConfigration_ResturantVenue");
        });

        modelBuilder.Entity<ResturantOffer>(entity =>
        {
            entity.ToTable("ResturantOffer");

            entity.HasOne(d => d.Resturant).WithMany(p => p.ResturantOffers)
                .HasForeignKey(d => d.ResturantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResturantOffer_Resturant");
        });

        modelBuilder.Entity<ResturantVenue>(entity =>
        {
            entity.ToTable("ResturantVenue");

            entity.HasOne(d => d.Resturant).WithMany(p => p.ResturantVenues)
                .HasForeignKey(d => d.ResturantId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ResturantVenue_Resturant");
        });

        modelBuilder.Entity<SignUpUser>(entity =>
        {
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(500);
        });

        modelBuilder.Entity<tblAuthentication>(entity =>
        {
            entity.ToTable("tblAuthentication");

            entity.Property(e => e.Password).HasMaxLength(500);
            entity.Property(e => e.UserCode).HasMaxLength(20);
            entity.Property(e => e.createdBy).HasColumnType("text");
            entity.Property(e => e.creationDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
