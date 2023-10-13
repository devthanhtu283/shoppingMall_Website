using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public interface TimeSlotService
    {
        public dynamic Add(TimeSlot timeSlot);
        public dynamic Update(TimeSlot timeSlot);
        public dynamic Delete(int id);
        public dynamic GetList();
        public dynamic GetItem(int id);
    }
}
