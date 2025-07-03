using System;
using System.Collections.Generic;

namespace WebMVC_SWD.Components.Books.Models;

public partial class BookCategory
{
    public int CategoryId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
