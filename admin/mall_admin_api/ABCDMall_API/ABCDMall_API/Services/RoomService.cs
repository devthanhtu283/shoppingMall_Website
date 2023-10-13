using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public interface RoomService
    {
        public dynamic Add(Room room);
        public dynamic Delete(int id);
        public dynamic GetList();
        public dynamic GetItem(int id);
    }
}
