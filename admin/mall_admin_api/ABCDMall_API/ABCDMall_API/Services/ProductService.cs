using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public interface ProductService
    {
        public dynamic findAll();
        public bool create(Product product);
        public bool delete(int id);
        public bool update(Product product);
        public dynamic findByKeyword(string keyword);
        public dynamic findById(int id);
        public Product findById2(int id);

    }
}
