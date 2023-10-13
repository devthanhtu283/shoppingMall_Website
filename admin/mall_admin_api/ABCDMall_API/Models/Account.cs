using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class Account
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Gender { get; set; }

    public bool? Status { get; set; }

    public DateTime? Dob { get; set; }

    public DateTime? Created { get; set; }
}
