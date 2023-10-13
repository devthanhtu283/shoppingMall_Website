using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public interface GalleryService
    {
        public dynamic findAll();
        public bool create( Newsgallery gallery);
        public bool delete(int id);
        public bool update(Newsgallery gallery);
        public Newsgallery findById2(int id);
        public dynamic findById(int id);
    }
}
