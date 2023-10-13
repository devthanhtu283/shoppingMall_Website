namespace DOANWEBAPI.Services
{
    public interface productService
    {
        public dynamic findAll();
		public dynamic findByName(string name);
		public dynamic Asc();
		public dynamic Desc();
		public dynamic Sale();
	}
}
