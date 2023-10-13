using System;
using System.Collections.Generic;

namespace DOANWEBAPI.Models;

public partial class Sale
{
    public int Id { get; set; }

    public double? SaleNumber { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
