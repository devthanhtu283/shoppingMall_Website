using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public class productServiceImpl : productService
    {
        private DatabaseContext db;
        private IConfiguration configuration;
        public productServiceImpl(DatabaseContext _db, IConfiguration _configuration)
        {
            this.db = _db;
            this.configuration = _configuration;
        }

		public dynamic Asc()
		{
			return db.Products.OrderBy(p => p.Price).Select(c => new
			{
				Id = c.Id,
				Name = c.Name,
				Image = configuration["BaseUrl"] + "img/" + c.Image,
				Price = c.Price,
				Description = c.Description,
				Idsale = c.Idsale,
				saleNumber = c.IdsaleNavigation.SaleNumber,
                startSale = c.IdsaleNavigation.StartDate,
                endSale = c.IdsaleNavigation.EndDate,
            }).ToList();
		}

		public dynamic Desc()
		{
			return db.Products.OrderByDescending(p => p.Price).Select(c => new
			{
				Id = c.Id,
				Name = c.Name,
				Image = configuration["BaseUrl"] + "img/" + c.Image,
				Price = c.Price,
				Description = c.Description,
				Idsale = c.Idsale,
				saleNumber = c.IdsaleNavigation.SaleNumber,
                startSale = c.IdsaleNavigation.StartDate,
                endSale = c.IdsaleNavigation.EndDate
            }).ToList();
		}

		public dynamic findAll()
        {
            return db.Products.Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                Image = configuration["BaseUrl"] + "img/" + c.Image,
                Price = c.Price,
                Description = c.Description,
                Idsale = c.Idsale,
				saleNumber = c.IdsaleNavigation.SaleNumber,
                startSale = c.IdsaleNavigation.StartDate,
                endSale = c.IdsaleNavigation.EndDate,
            }).ToList();
        }
		public dynamic findByName(string name)
		{
			return db.Products.Where(c => c.Name.Contains(name)).Select(c => new
			{
				Id = c.Id,
				Name = c.Name,
				Image = configuration["BaseUrl"] + "img/" + c.Image,
				Price = c.Price,
				Description = c.Description,
				Idsale = c.Idsale,
                saleNumber = c.IdsaleNavigation.SaleNumber,
                startSale = c.IdsaleNavigation.StartDate,
                endSale = c.IdsaleNavigation.EndDate,
            }).ToList();
		}

        public dynamic Sale()
        {
            return db.Products.Where(c => c.Idsale != null).Select(c => new
            {
                Id = c.Id,
                Name = c.Name,
                Image = configuration["BaseUrl"] + "img/" + c.Image,
                Price = c.Price,
                Description = c.Description,
                Idsale = c.Idsale,
                saleNumber = c.IdsaleNavigation.SaleNumber,
                startSale = c.IdsaleNavigation.StartDate,
                endSale = c.IdsaleNavigation.EndDate,
            }).ToList();
        }
    }
}
