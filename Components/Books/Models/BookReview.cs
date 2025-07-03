using System;
using System.Collections.Generic;

namespace WebMVC_SWD.Components.Books.Models;

public partial class BookReview
{
    public int ReviewId { get; set; }

    public string? Content { get; set; }

    public int? CustomerId { get; set; }

    public int? BookId { get; set; }

    public int? BookRate { get; set; }

    public virtual Book? Book { get; set; }
}
