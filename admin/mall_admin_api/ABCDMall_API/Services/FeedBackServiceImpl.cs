using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public class FeedBackServiceImpl : FeedBackService
    {
        private DatabaseContext db;

        public FeedBackServiceImpl(DatabaseContext _db)
        {
            db = _db;
        }

        public bool create(Feedback feedback)
        {
            try
            {
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

        public dynamic findById(int id)
        {
            return db.Feedbacks.Where(s => s.Id == id).Select(s => new
            {
                Id = s.Id,
                Name = s.Name,
                Value = s.Value,
                Title = s.Title,
                Message = s.Message,
                Created = s.Created
            }).FirstOrDefault();
        }

    }
}
