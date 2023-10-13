using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class Show
{
    public int Id { get; set; }

    public DateTime DateRelease { get; set; }

    public double Price { get; set; }

    public bool Status { get; set; }

    public int RoomId { get; set; }

    public int MovieId { get; set; }

    public int TimeSlotId { get; set; }

    public virtual Movie Movie { get; set; } = null!;

    public virtual Room Room { get; set; } = null!;

    public virtual ICollection<SeatStatus> SeatStatuses { get; set; } = new List<SeatStatus>();

    public virtual TimeSlot TimeSlot { get; set; } = null!;
}
