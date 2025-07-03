using System;
using System.Collections.Generic;

namespace WebMVC_SWD.Components.ReturnRequests.Models;

public partial class ReturnRequest
{
    public int ReturnId { get; set; }

    public int? OrderId { get; set; }

    public string Reason { get; set; } = null!;

    public DateTime? RequestDate { get; set; }

    public string? Status { get; set; }

    public string? Note { get; set; }
}
