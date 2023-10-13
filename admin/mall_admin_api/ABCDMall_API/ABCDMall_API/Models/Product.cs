using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Image { get; set; }

    public double? Price { get; set; }

    public string? Description { get; set; }

    public int? Idsale { get; set; }

    public int? Idcategory { get; set; }

    public virtual Category? IdcategoryNavigation { get; set; }

    public virtual Sale? IdsaleNavigation { get; set; }
}
