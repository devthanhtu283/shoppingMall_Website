using DOANWEBAPI.Models;


using System.Diagnostics;
using System.Linq;
namespace DOANWEBAPI.Services

{
    public class ShowServiceImpl : ShowService
    {
        private DatabaseContext _db;
        private IConfiguration _configuration;
        public ShowServiceImpl(DatabaseContext db, IConfiguration configuration)
        {
            _db = db;
            _configuration = configuration;
        }
        public dynamic Add(Show show)
        {
            try
            {
                var oldShow = _db.Shows.Count(s => s.RoomId == show.RoomId && s.TimeSlotId == show.TimeSlotId && s.DateRelease == show.DateRelease && s.Status == true) > 0;
                var existShow = _db.Shows.Count(s => s.RoomId == show.RoomId && s.TimeSlotId == show.TimeSlotId && s.DateRelease == show.DateRelease && s.Status == true && s.MovieId == show.MovieId) > 0;

                var seats = _db.Seats.Where(s => s.RoomId == show.RoomId).Select(s => new
                { Id = s.Id }
                ).ToList();

                int[] seatIdList = new int[seats.Count];

                for (int i = 0; i < seats.Count; i++)
                {
                    int value = seats[i].Id;
                    seatIdList[i] = value;
                }

                if (existShow)
                {
                    return "show already exist";
                }
                else if (oldShow)
                {
                    return "already exist another show";
                }
                else
                {
                    _db.Shows.Add(show);
                    _db.SaveChanges();

                    if (show.Id > 0)
                    {
                        for (int i = 0; i < seatIdList.Length; i++)
                        {
                            var seatStatus = new SeatStatus { SeatId = seatIdList[i], ShowId = show.Id, Status = true };
                            _db.SeatStatuses.Add(seatStatus);
                        }
                    }
                    return _db.SaveChanges() > 0;
                }
            }
            catch
            {
                return false;
            }
        }
        public dynamic Delete(int id)
        {
            try
            {
                var show = _db.Shows.Find(id);
                var seatStatues = _db.SeatStatuses.Where(st => st.ShowId == id).ToList();

                if (show != null)
                {
                    show.Status = false;

                    if (seatStatues != null)
                    {
                        for (int i = 0; i < seatStatues.Count; i++)
                        {
                            var seatStatus = seatStatues[i];
                            seatStatus.Status = false;
                            _db.Entry(seatStatus).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            _db.SaveChanges();
                        }

                        _db.Entry(show).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        return _db.SaveChanges() > 0;
                    }
                    else
                    {
                        _db.Entry(show).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        return _db.SaveChanges() > 0;
                    }
                }
                else
                {
                    return "not found";
                }
            }
            catch
            {
                return false;
            }
        }
        public dynamic GetList()
        {
            return _db.Shows.Where(s => s.Status == true).Select(s => new
            {
                Id = s.Id,
                Price = s.Price,
                DateRelease = s.DateRelease,
                StartTime = _db.TimeSlots.FirstOrDefault(ts => ts.Id == s.TimeSlotId).StartTime,
                Movie = _db.Movies.Where(m => m.Id == s.MovieId).Select(m => new
                {
                    Name = m.Name,
                    Photo = _configuration["BaseUrl"] + "img/" + m.Photo,
                    Language = m.Language,
                    Genre = m.Genre
                }).ToList(),

            }).ToList();
        }
        public dynamic GetListByDateRelease(DateTime dateRelease)
        {
            return _db.Shows
        .Where(s => s.Status == true && s.DateRelease == dateRelease)
        .GroupBy(showtime => new
        {
            showtime.Movie.Id,
            showtime.Movie.Name,
            showtime.Movie.Photo,
            showtime.Movie.Language,
            showtime.Movie.Genre,
            showtime.Movie.TimeLast,
        })
        .Select(groupedShowtimes => new
        {
            movieId = groupedShowtimes.Key.Id,
            movieName = groupedShowtimes.Key.Name,
            moviePhoto = _configuration["BaseUrl"] + "img/" + groupedShowtimes.Key.Photo,
            movieLanguage = groupedShowtimes.Key.Language,
            movieGenre = groupedShowtimes.Key.Genre,
            movieTimeLast = groupedShowtimes.Key.TimeLast,
            showTimes = groupedShowtimes.Select(showtime => new
            {
                id = showtime.Id,
                price = showtime.Price,
                dateRelease = showtime.DateRelease,
                StartTime = _db.TimeSlots.FirstOrDefault(ts => ts.Id == showtime.TimeSlotId).StartTime,

            }).ToList()
        })
        .ToList();
        }

        public dynamic GetItem(int id)
        {
            var show = _db.Shows.Find(id);

            if (show != null && show.Status == true)
            {
                return _db.Shows.Where(s => s.Id == id && s.Status == true).Select(s => new
                {
                    Id = s.Id,
                    Price = s.Price,
                    DateRelease = s.DateRelease,
                    StartTime = _db.TimeSlots.FirstOrDefault(ts => ts.Id == s.TimeSlotId).StartTime,
                    Movie = _db.Movies.Where(m => m.Id == s.MovieId).Select(m => new
                    {
                        Name = m.Name,
                        TimeLast = m.TimeLast,
                        Photo = _configuration["BaseUrl"] + "img/" + m.Photo,
                        Language = m.Language,
                        Genre = m.Genre,
                        Description = m.Description
                    }).FirstOrDefault(),
                    Room = _db.Rooms.Where(r => r.Id == s.RoomId).Select(r => new
                    {
                        Id = r.Id,
                        Name = r.Name,
                        Row = r.Row,
                        Col = r.Col,
                    }).FirstOrDefault(),
                    SeatStatues = _db.SeatStatuses.Where(st => st.ShowId == id).Select(st => new
                    {
                        Id = st.Id,
                        Status = st.Status,
                        Seat = _db.Seats.Where(s => s.Id == st.SeatId).Select(s => new
                        {
                            Id = s.Id,
                            RoomId = s.RoomId,
                            Name = s.Name,
                            Row = s.Row,
                            Col = s.Col,
                            Status =s.Status
                        }).FirstOrDefault(),
                    }).ToList()
                }).FirstOrDefault();
            }
            else if (show != null && show.Status == false)
            {
                return "show has been delete";
            }
            else
            {
                return "not found";
            }
        }

    }
}
