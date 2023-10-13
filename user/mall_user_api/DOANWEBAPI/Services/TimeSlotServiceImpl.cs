
using System.Diagnostics.Eventing.Reader;
using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public class TimeSlotServiceImpl : TimeSlotService
    {
        private DatabaseContext _db;
        public TimeSlotServiceImpl(DatabaseContext db)
        {
            _db = db;
        }
        public dynamic Add(TimeSlot timeSlot)
        {
            try
            {
                _db.TimeSlots.Add(timeSlot);
                return _db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
        public dynamic Update(TimeSlot timeSlot)
        {
            try
            {
                var currentTimeSlot = _db.TimeSlots.Find(timeSlot.Id);
                if (currentTimeSlot != null && currentTimeSlot.Status == true)
                {
                    currentTimeSlot.Name = timeSlot.Name;
                    currentTimeSlot.StartTime = timeSlot.StartTime;
                    currentTimeSlot.EndTime = timeSlot.EndTime;

                    _db.Entry(timeSlot).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return _db.SaveChanges() > 0;
                }
                else if (currentTimeSlot != null && currentTimeSlot.Status == false)
                {
                    return "time slot has been delete";
                }
                else
                {
                    return "not found";
                }
            }
            catch
            {
                return false;
            }
        }
        public dynamic Delete(int id)
        {
            try
            {
                var currentTimeSlot = _db.TimeSlots.Find(id);

                if (currentTimeSlot != null)
                {
                    currentTimeSlot.Status = false;

                    _db.Entry(currentTimeSlot).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    return _db.SaveChanges() > 0;
                }
                else if (currentTimeSlot != null && currentTimeSlot.Status == false)
                {
                    return "time slot has been delete";
                }
                else
                {
                    return "not found";
                }
            }
            catch
            {

                return false;
            }
        }
        public dynamic GetList()
        {
            return _db.TimeSlots.Where(ts => ts.Status == true).Select(ts => new
            {
                Id = ts.Id,
                Name = ts.Name,
                StartTime = ts.StartTime,
                EndTime = ts.EndTime,
            }).ToList();
        }
        public dynamic GetItem(int id)
        {
            var timeSlot = _db.TimeSlots.Find(id);
            if (timeSlot != null && timeSlot.Status == true)
            {
                return _db.TimeSlots.Where(ts => ts.Id == id).Select(ts => new
                {
                    Id = ts.Id,
                    Name = ts.Name,
                    StartTime = ts.StartTime,
                    EndTime = ts.EndTime,
                }).ToList();
            }
            else if (timeSlot != null && timeSlot.Status == false)
            {
                return "time slot has been delete";
            }
            else
            {
                return "not found";
            }
        }

    }
}
