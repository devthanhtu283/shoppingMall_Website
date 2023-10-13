using System;
using System.Collections.Generic;

namespace DOANWEBAPI.Models;

public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Row { get; set; }

    public int Col { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
