using System;
using System.Collections.Generic;

namespace DOANWEBAPI.Models;

public partial class Shop
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? CoverImg { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
