using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public class CategoryServiceImpl : CategoryService
    {
        private DatabaseContext db;

        public CategoryServiceImpl(DatabaseContext _db) 
        {
            db = _db;
        }
        public dynamic findAll()
        {
            return db.Categories.Select(c => new
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
        }
    }
}
