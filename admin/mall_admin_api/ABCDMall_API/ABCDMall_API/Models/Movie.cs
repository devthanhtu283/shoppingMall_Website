using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class Movie
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Photo { get; set; } = null!;

    public string Description { get; set; } = null!;

    public TimeSpan TimeLast { get; set; }

    public DateTime DateExpect { get; set; }

    public string Genre { get; set; } = null!;

    public string Language { get; set; } = null!;

    public bool Status { get; set; }

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
