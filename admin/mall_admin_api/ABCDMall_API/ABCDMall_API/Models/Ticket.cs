using System;
using System.Collections.Generic;

namespace ABCDMall_API.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public string NameCustomer { get; set; } = null!;

    public string PhoneCustomer { get; set; } = null!;

    public DateTime TimeBooked { get; set; }

    public bool Status { get; set; }

    public int SeatStatusId { get; set; }

    public virtual SeatStatus SeatStatus { get; set; } = null!;
}
