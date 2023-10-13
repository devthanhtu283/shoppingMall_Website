using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public interface RoomService
    {
        public dynamic Add(Room room);
        public dynamic Delete(int id);
        public dynamic GetList();
        public dynamic GetItem(int id);
    }
}
