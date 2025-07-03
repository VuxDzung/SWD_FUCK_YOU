using System;
using System.Collections.Generic;

namespace WebMVC_SWD.Components.DiscountBooks.Models;

public partial class DiscountByBook
{
    public int DiscountId { get; set; }

    public int? BookId { get; set; }

    public decimal? DiscountPercentage { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
}
