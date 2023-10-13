using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
	public class GallaryServiceImpl : GallaryService
	{
		private DatabaseContext db;
		private IConfiguration configuration;
		public GallaryServiceImpl(DatabaseContext _db, IConfiguration configuration) {
			db = _db;
			this.configuration = configuration;
		}
		public dynamic findAll()
		{
			return db.Newsgalleries.Select(n => new
			{
				Id = n.Id,
				CoverImg = configuration["BaseUrl"] + "img/" + n.CoverImg,
				Description = n.Description,
			}).ToList();
		}
	}
}