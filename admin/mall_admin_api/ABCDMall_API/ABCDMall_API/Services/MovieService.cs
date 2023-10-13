using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public interface MovieService
    {

        public dynamic create(Movie movie);
        public dynamic update(Movie movie);
        public dynamic delete(int id);
        public dynamic findAll();
        public dynamic findbyId(int id);
        public dynamic findbyId2(int id);
        public dynamic findByKeyword(string keyword);
    }
}
