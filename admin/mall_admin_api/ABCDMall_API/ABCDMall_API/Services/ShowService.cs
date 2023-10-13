using ABCDMall_API.Models;

namespace ABCDMall_API.Services


{
    public interface ShowService
    {
        public dynamic Add(Show show);
        public dynamic Delete(int id);
        public dynamic GetList();
        public dynamic GetItem(int id);
        public dynamic GetListByDateRelease(DateTime dateRelease);
    }
}
