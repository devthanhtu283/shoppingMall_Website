using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public interface StoreService
    {
        public dynamic findAll();
        public bool create(Shop shop);
        public bool delete(int id);
        public dynamic findByKeyword(string keyword);
        public dynamic findById(int id);
        public Shop findById2(int id);
        public bool update(Shop shop);
    }
}
