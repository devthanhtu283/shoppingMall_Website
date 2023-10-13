using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class TimeSlot
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public bool Status { get; set; }

    public virtual ICollection<Show> Shows { get; set; } = new List<Show>();
}
