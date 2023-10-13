using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Shop> Shops { get; set; } = new List<Shop>();
}
