using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebMVC_SWD.Components.ReturnRequests.Models;

public partial class ReturnRequestDBContext : DbContext
{
    public ReturnRequestDBContext()
    {
    }

    public ReturnRequestDBContext(DbContextOptions<ReturnRequestDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ReturnRequest> ReturnRequests { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UGQUIT4\\RICHARDVU;Database=BookShopDB;User Id=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ReturnRequest>(entity =>
        {
            entity.HasKey(e => e.ReturnId).HasName("PK__ReturnRe__EBA76319A6F7756A");

            entity.ToTable("ReturnRequest");

            entity.HasIndex(e => e.OrderId, "UQ__ReturnRe__0809335C5CFC7F28").IsUnique();

            entity.Property(e => e.ReturnId).HasColumnName("returnId");
            entity.Property(e => e.Note)
                .HasColumnType("text")
                .HasColumnName("note");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.Reason)
                .HasColumnType("text")
                .HasColumnName("reason");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("requestDate");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pending")
                .HasColumnName("status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
