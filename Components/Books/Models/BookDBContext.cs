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
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("MyCnn"));
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.BookId).HasName("PK__Book__8BE5A10D8212183A");

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
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("isActive");
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
                .HasConstraintName("FK__Book__categoryId__3E52440B");
        });

        modelBuilder.Entity<BookCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__BookCate__23CAF1D88520D7FB");

            entity.ToTable("BookCategory");

            entity.Property(e => e.CategoryId).HasColumnName("categoryId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<BookReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__BookRevi__2ECD6E044D6E2F9B");

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
                .HasConstraintName("FK__BookRevie__bookI__5165187F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
