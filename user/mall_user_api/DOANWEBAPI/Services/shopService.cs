using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public interface shopService
    {
        public dynamic findAll();
		public dynamic findByCategoryID(int id);
		public dynamic findByName(string name, int categoryID);
		
	}
}
