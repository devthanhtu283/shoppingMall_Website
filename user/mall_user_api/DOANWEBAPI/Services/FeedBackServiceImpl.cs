using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services
{
    public class FeedBackServiceImpl : FeedBackService
    {
        private DatabaseContext db;
        private IConfiguration configuration;

        public FeedBackServiceImpl(DatabaseContext _db, IConfiguration _configuration)
        {
            db = _db;
            configuration = _configuration;
        }
        public bool create(Feedback feedback)
        {
            try
            {
                feedback.Created= DateTime.Now;
                feedback.Status = false;
                db.Feedbacks.Add(feedback);
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
                db.Feedbacks.Remove(db.Feedbacks.Find(id));
                return db.SaveChanges() > 0;
            }
            catch
            {
                return false;
            }
        }

        public dynamic findAll()
        {
            return db.Feedbacks.Select(s => new

            {
                Id = s.Id,
                Name = s.Name,
                Value = s.Value,
                Title = s.Title,
                Message = s.Message,
                Created = s.Created
            }).ToList();
        }
    }
}
