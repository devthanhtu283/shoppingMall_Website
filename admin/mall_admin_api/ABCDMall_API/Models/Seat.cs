using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class Seat
{
    public int Id { get; set; }

    public int Row { get; set; }

    public int Col { get; set; }

    public bool Status { get; set; }

    public int RoomId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual ICollection<SeatStatus> SeatStatuses { get; set; } = new List<SeatStatus>();
}
