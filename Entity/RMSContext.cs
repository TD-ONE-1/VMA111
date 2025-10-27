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

    public virtual DbSet<SignUpUser> SignUpUsers { get; set; }

    public virtual DbSet<tblAuthentication> tblAuthentications { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=RMS;Data Source=IT-DHP-2300718\\MSSQLSERVER01; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
