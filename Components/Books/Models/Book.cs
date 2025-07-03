using System;
using System.Collections.Generic;

namespace WebMVC_SWD.Components.Books.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Name { get; set; }

    public string? Author { get; set; }

    public decimal? Price { get; set; }

    public string? Isbn { get; set; }

    public string? Publisher { get; set; }

    public int? PublicationYear { get; set; }

    public int? Stock { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public virtual ICollection<BookReview> BookReviews { get; set; } = new List<BookReview>();

    public virtual BookCategory? Category { get; set; }
}
