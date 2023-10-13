using ABCDMall_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCDMall_API.Services
{
    public class StoreServiceImpl : StoreService
    {
        private DatabaseContext db;
        private IConfiguration configuration;

        public StoreServiceImpl(DatabaseContext _db, IConfiguration _configuration)
        {
            db = _db;
            configuration = _configuration;
        }

        public dynamic findAll()
        {
            return db.Shops.Select(s => new

            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                CoverImg = configuration["BaseUrl"] + "img/" + s.CoverImg,
                CategoryId = s.CategoryId
            }).ToList();
        }

        public bool create(Shop shop)
        {
            try
            {
                db.Shops.Add(shop);
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool delete(int id)
        {
            try
            {
                db.Shops.Remove(db.Shops.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findByKeyword(string keyword)
        {
            return db.Shops.Where(s => s.Name.Contains(keyword)).Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                CoverImg = configuration["BaseUrl"] + "img/" + s.CoverImg,
                CategoryId = s.CategoryId
            }).ToList();
        }

        public dynamic findById(int id)
        {
            return db.Shops.Where(s => s.Id == id).Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                CoverImg = configuration["BaseUrl"] + "img/" + s.CoverImg,
                CategoryId = s.CategoryId
            }).FirstOrDefault();
        }

        public Shop findById2(int id)
        {
            return db.Shops.AsNoTracking().SingleOrDefault(s => s.Id == id);
        }

        public bool update(Shop shop)
        {
            try
            {
                db.Entry(shop).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
