using ABCDMall_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCDMall_API.Services
{
    public class GalleryServiceImpl : GalleryService
    {
        private DatabaseContext db;
        private IConfiguration configuration;

        public GalleryServiceImpl(DatabaseContext _db, IConfiguration _configuration)
        {
            db = _db;
            configuration = _configuration;
        }
        public bool create(Newsgallery gallery)
        {
            try
            {
                db.Newsgalleries.Add(gallery);
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
                db.Newsgalleries.Remove(db.Newsgalleries.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Newsgalleries.Select(s => new

            {
                Id = s.Id,
                CoverImg = configuration["BaseUrl"] + "img/" + s.CoverImg,
                Description = s.Description,
            }).ToList();
        }

        public dynamic findById(int id)
        {
            return db.Shops.Where(s => s.Id == id).Select(s => new
            {
                Id = s.Id,
                CoverImg = configuration["BaseUrl"] + "img/" + s.CoverImg,
                Description = s.Description,
            }).FirstOrDefault();
        }

        public Newsgallery findById2(int id)
        {
            return db.Newsgalleries.AsNoTracking().SingleOrDefault(s => s.Id == id);
        }

        public bool update(Newsgallery gallery)
        {
            try
            {
                db.Entry(gallery).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
