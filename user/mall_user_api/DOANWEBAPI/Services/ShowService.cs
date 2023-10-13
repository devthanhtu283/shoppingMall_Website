using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services


{
    public interface ShowService
    {
        public dynamic Add(Show show);
        public dynamic Delete(int id);
        public dynamic GetList();
        public dynamic GetListByDateRelease(DateTime dateRelease);
        public dynamic GetItem(int id);
    }
}
