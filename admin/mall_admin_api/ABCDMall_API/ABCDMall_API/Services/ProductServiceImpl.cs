using ABCDMall_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCDMall_API.Services
{
    public class ProductServiceImpl : ProductService
    {
        private DatabaseContext db;
        private IConfiguration configuration;

        public ProductServiceImpl(DatabaseContext _db, IConfiguration _configuration)
        {
            db = _db;
            configuration = _configuration;
        }
        public bool create(Product product)
        {
            try
            {
                    db.Products.Add(product);
                    return db.SaveChanges()>0;
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
                db.Products.Remove(db.Products.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public bool update(Product product)
        {
            try
            {
                db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Products.Select(p => new

            {
                Id = p.Id,
                Name = p.Name,
                Image = configuration["BaseUrl"] + "img/" + p.Image,
                Price = p.Price,
                Description = p.Description,
                Idsale = p.Idsale,
                Idcategory = p.Idcategory
            }).ToList();
        }

        public dynamic findById(int id)
        {
            return db.Products.Where(p => p.Id == id).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Image = configuration["BaseUrl"] + "img/" + p.Image,
                Price = p.Price,
                Description = p.Description,
                Idsale = p.Idsale,
                Idcategory = p.Idcategory
            }).FirstOrDefault();
        }

        public Product findById2(int id)
        {
            return db.Products.AsNoTracking().SingleOrDefault(p => p.Id == id);
        }

        public dynamic findByKeyword(string keyword)
        {
            return db.Products.Where(p => p.Name.Contains(keyword)).Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Image = configuration["BaseUrl"] + "img/" + p.Image,
                Price = p.Price,
                Description = p.Description,
                Idsale = p.Idsale,
                Idcategory = p.Idcategory
            }).ToList();
        }

        
    }
}
