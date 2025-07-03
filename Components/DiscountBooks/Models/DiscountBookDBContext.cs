using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebMVC_SWD.Components.DiscountBooks.Models;

public partial class DiscountBookDBContext : DbContext
{
    public DiscountBookDBContext()
    {
    }

    public DiscountBookDBContext(DbContextOptions<DiscountBookDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiscountByBook> DiscountByBooks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UGQUIT4\\RICHARDVU;Database=BookShopDB;User Id=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiscountByBook>(entity =>
        {
            entity.HasKey(e => e.DiscountId).HasName("PK__Discount__D2130A66088525D0");

            entity.ToTable("DiscountByBook");

            entity.Property(e => e.DiscountId).HasColumnName("discountId");
            entity.Property(e => e.BookId).HasColumnName("bookId");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discountPercentage");
            entity.Property(e => e.EndDate).HasColumnName("endDate");
            entity.Property(e => e.StartDate).HasColumnName("startDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
