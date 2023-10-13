using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public interface FeedBackService
    {
        public dynamic findAll();
        public bool create(Feedback feedback);
        public bool delete(int id);
        public dynamic findById(int id);
    }
}
