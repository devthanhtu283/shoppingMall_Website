using System;
using System.Collections.Generic;

namespace DOANWEBAPI.Models;

public partial class Feedback
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public bool? Status { get; set; }
    public int? Value { get; set; }

    public string? Message { get; set; }

    public DateTime? Created { get; set; }
}
