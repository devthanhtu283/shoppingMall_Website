
using System.Diagnostics.Metrics;

using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public class SeatServiceImpl : SeatService
    {
        private DatabaseContext _db;
        public SeatServiceImpl(DatabaseContext db)
        {
            _db = db;
        }
        public dynamic Update(Seat seat)
        {
            var currentSeat = _db.Seats.Find(seat.Id);

            if (currentSeat == null)
            {
                return "not found";
            }
            else
            {
                currentSeat.Status = seat.Status;

                _db.Entry(currentSeat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return _db.SaveChanges() > 0;
            }
        }



    }
}
