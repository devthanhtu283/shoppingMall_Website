using System;
using System.Collections.Generic;

namespace DOANWEBAPI.Models;

public partial class SeatStatus
{
    public int Id { get; set; }

    public bool Status { get; set; }

    public int SeatId { get; set; }

    public int ShowId { get; set; }

    public virtual Seat Seat { get; set; } = null!;

    public virtual Show Show { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
