using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public interface MovieService
    {
        public dynamic Add(Movie movie);
        public dynamic Update(Movie movie);
        public dynamic Delete(int id);
        public dynamic GetList();
        public dynamic Find(int id);
        public dynamic GetItem(int id);
    }
}
