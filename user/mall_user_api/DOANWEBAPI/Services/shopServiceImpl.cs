using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public class shopServiceImpl : shopService
    {
		private DatabaseContext db;
		private IConfiguration configuration;

		public shopServiceImpl(DatabaseContext _db, IConfiguration _configuration)
		{
			this.db = _db;
			this.configuration = _configuration;
		}

		

		public dynamic findAll()
        {
            return db.Shops.Select(c=> new

            {
                Id=c.Id,
                Name=c.Name,
                Description=c.Description,
                CoverImg=c.CoverImg,
                CategoryId=c.CategoryId,
            }).ToList();
        }
		public dynamic findByCategoryID(int id)
		{
			return db.Shops.Where(c => c.CategoryId == id).Select(c => new

			{
				Id = c.Id,
				Name = c.Name,
				Description = c.Description,
				CoverImg = configuration["BaseUrl"] + "img/" + c.CoverImg,
				CategoryId = c.CategoryId,
			}).ToList();
		}

		public dynamic findByName(string name, int categoryID)
		{
			return db.Shops.Where(c => c.Name.Contains(name) && c.CategoryId == categoryID).Select(c => new

			{
				Id = c.Id,
				Name = c.Name,
				Description = c.Description,
				CoverImg = configuration["BaseUrl"] + "img/" + c.CoverImg,
				CategoryId = c.CategoryId,
			}).ToList();
		}
	}
}
