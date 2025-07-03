using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebMVC_SWD.Components.Books.Models;

public partial class BookDBContext : DbContext
{
    public BookDBContext()
    {
    }

    public BookDBContext(DbContextOptions<BookDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<BookCategory> BookCategories { get; set; }

    public virtual DbSet<BookReview> BookReviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-UGQUIT4\\RICHARDVU;Database=BookShopDB;User Id=sa;Password=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__8BE5A10DAB936007");

            entity.ToTable("Book");

            entity.Property(e => e.BookId).HasColumnName("bookId");
            entity.Property(e => e.Author)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("author");
            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Isbn)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("isbn");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.PublicationYear).HasColumnName("publicationYear");
            entity.Property(e => e.Publisher)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("publisher");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Category).WithMany(p => p.Books)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Book__categoryId__3D5E1FD2");
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__BookCate__23CAF1D86B7CD357");

            entity.ToTable("BookCategory");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BookReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__BookRevi__2ECD6E04929319E5");

            entity.ToTable("BookReview");

            entity.Property(e => e.ReviewId).HasColumnName("reviewId");
            entity.Property(e => e.BookId).HasColumnName("bookId");
            entity.Property(e => e.BookRate).HasColumnName("bookRate");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");

            entity.HasOne(d => d.Book).WithMany(p => p.BookReviews)
                .HasForeignKey(d => d.BookId)
                .HasConstraintName("FK__BookRevie__bookI__5070F446");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
