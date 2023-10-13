using DOANWEBAPI.Models;
using System.Diagnostics;
using System.Net.Sockets;

namespace DOANWEBAPI.Services
{
    public class TicketServiceImpl : TicketService
    {
        private DatabaseContext _db;
        public TicketServiceImpl(DatabaseContext db)
        {
            _db = db;
        }
        public dynamic Add(Ticket[] tickets)
        {
            try
            {
                int[] soldOutTickets = new int[tickets.Length];

                for (int i = 0; i < tickets.Length; i++)
                {
                    if (_db.SeatStatuses.Count(st => st.Id == tickets[i].SeatStatusId && st.Status == false) > 0)
                    {
                        var seatStatusId = tickets[i].SeatStatusId;
                        soldOutTickets[i] = seatStatusId;
                    }
                }


                soldOutTickets = soldOutTickets.Where(x => x != 0).ToArray();

                string[] soldoutSeats = new string[soldOutTickets.Length];

                for (int i = 0; i < soldOutTickets.Length; i++)
                {
                    var seatId = _db.SeatStatuses.FirstOrDefault(st => st.Id == soldOutTickets[i]).SeatId;
                    var seatName = _db.Seats.FirstOrDefault(s => s.Id == seatId).Name;
                    soldoutSeats[i] = seatName + " is sold out";
                }

                if (soldOutTickets.Length > 0)
                {
                    return soldoutSeats;
                }
                else
                {
                    for (int i = 0; i < tickets.Length; i++)
                    {
                        _db.Tickets.Add(tickets[i]);
                        _db.SaveChanges();

                        if (tickets[i].Id > 0)
                        {
                            var seatStatus = _db.SeatStatuses.Find(tickets[i].SeatStatusId);

                            seatStatus.Status = false;

                            _db.Entry(seatStatus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        }
                    }
                    return _db.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
        public dynamic GetItem(int id)
        {
            var ticket = _db.Tickets.Find(id);

            if (ticket != null)
            {
                return _db.Tickets.Where(t => t.Id == id).Select(t => new
                {
                    NameCustomer = t.NameCustomer,
                    PhoneCustomer = t.PhoneCustomer,
                    TimeBooked = t.TimeBooked,
                    Status = t.Status,
                    SeatStatusId = t.SeatStatusId
                }).ToList();
            }
            else
            {
                return "not found";
            }
        }
        public dynamic GetListByCustomerName(string customerName)
        {
            return _db.Tickets.Where(t => t.NameCustomer.Contains(customerName)).Select(t => new
            {
                NameCustomer = t.NameCustomer,
                PhoneCustomer = t.PhoneCustomer,
                TimeBooked = t.TimeBooked,
                Status = t.Status,
                SeatStatusId = t.SeatStatusId
            }).ToList();
        }
        public dynamic GetListByCustomerPhone(string customerPhone)
        {
            return _db.Tickets.Where(t => t.PhoneCustomer.Contains(customerPhone)).Select(t => new
            {
                NameCustomer = t.NameCustomer,
                PhoneCustomer = t.PhoneCustomer,
                TimeBooked = t.TimeBooked,
                Status = t.Status,
                SeatStatusId = t.SeatStatusId
            }).ToList();
        }

    }
}
