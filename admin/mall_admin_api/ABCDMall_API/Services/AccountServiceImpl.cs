using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public class AccountServiceImpl : AccountService
    {
        private DatabaseContext db;

        public AccountServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }
        public bool login(string username, string password)
        {
            return db.Accounts.Count(a => a.Username == username && a.Password == password) > 0;
        }
    }
}
