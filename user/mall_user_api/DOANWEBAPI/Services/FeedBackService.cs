using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public interface FeedBackService
    {
        public dynamic findAll();
        public bool create(Feedback product);
        public bool delete(int id);
    }
}
