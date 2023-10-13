
using System.Diagnostics;

using ABCDMall_API.Models;

namespace ABCDMall_API.Services
{
    public class RoomServiceImpl : RoomService
    {
        private DatabaseContext _db;

        public RoomServiceImpl(DatabaseContext db)
        {
            _db = db;
        }

        public dynamic Add(Room room)
        {
            var row = room.Row;
            var col = room.Col;

            try
            {
                if (row <= 0 || col <= 0)
                {
                    return "row and column must be greater than 0";
                }
                else
                {
                    _db.Rooms.Add(room);
                    _db.SaveChanges();

                    if (room.Id > 0)
                    {
                        for (int i = 1; i <= row; i++)
                        {
                            for (int j = 1; j <= col; j++)
                            {
                                var seat = new Seat { Row = i, Col = j, Status = true, RoomId = room.Id, Name = (char)(64 + i) + string.Concat(j) };
                                _db.Seats.Add(seat);
                            }
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
                var room = _db.Rooms.Find(id);
                var seats = _db.Seats.Where(s => s.RoomId == id).ToList();

                if (room != null)
                {
                    room.Status = false;

                    if (seats != null)
                    {
                        for (int i = 0; i < seats.Count; i++)
                        {
                            var seat = seats[i];
                            seat.Status = false;
                            _db.Entry(seat).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            _db.SaveChanges();
                        }

                        _db.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        return _db.SaveChanges() > 0;
                    }
                    else
                    {
                        _db.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
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
            return _db.Rooms.Where(r => r.Status == true).Select(r => new
            {
                Id = r.Id,
                Name = r.Name,
                Row = r.Row,
                Col = r.Col,
            }).ToList();
        }

        public dynamic GetItem(int id)
        {
            var room = _db.Rooms.Find(id);

            if (room != null && room.Status == true)
            {
                return _db.Rooms.Where(r => r.Id == id && r.Status == true).Select(r => new
                {
                    Id = r.Id,
                    Name = r.Name,
                    Row = r.Row,
                    Col = r.Col,
                    Seats = _db.Seats.Where(s => s.RoomId == id).Select(s => new
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Status = s.Status,
                        RoomId = s.RoomId,

                    }).ToList()
                });
            }
            else if (room != null && room.Status == false)
            {
                return "room has been delete";
            }
            else
            {
                return "not found";
            }
        }

    }
}
