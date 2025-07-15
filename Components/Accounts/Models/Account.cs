using System;
using System.Collections.Generic;

namespace WebMVC_SWD.Components.Accounts.Models;

public partial class Account
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public string UserRole { get; set; } = null!;

    public int? Age { get; set; }

    public string? Address { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public bool IsDisabled { get; set; } 

}
