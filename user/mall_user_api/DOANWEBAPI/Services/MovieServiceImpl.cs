using DOANWEBAPI.Models;

namespace DOANWEBAPI.Services;

public class MovieServiceImpl : MovieService
{
    private DatabaseContext _db;
    private IConfiguration _configuration;
    public MovieServiceImpl(DatabaseContext db, IConfiguration configuration)
    {
        _db = db;
        _configuration = configuration;
    }
    public dynamic GetList()
    {
        return _db.Movies.Where(m => m.Status == true).Select(m => new
        {
            Id = m.Id,
            Name = m.Name,
            Photo = _configuration["BaseUrl"] + "img/" + m.Photo,
            Description = m.Description,
            TimeLast = m.TimeLast,
            DateExpect = m.DateExpect,
            Genre = m.Genre,
            Language = m.Language,
        }).ToList();
    }
    public dynamic Add(Movie movie)
    {
        try
        {
            _db.Movies.Add(movie);
            return _db.SaveChanges() > 0;
        }
        catch
        {
            return false;
        }
    }
    public dynamic Update(Movie movie)
    {
        try
        {
            var currentMovie = _db.Movies.Find(movie.Id);
            if (currentMovie != null && currentMovie.Status == true)
            {
                currentMovie.Name = movie.Name;
                currentMovie.Description = movie.Description;
                currentMovie.TimeLast = movie.TimeLast;
                currentMovie.DateExpect = movie.DateExpect;
                currentMovie.Genre = movie.Genre;
                currentMovie.Language = movie.Language;
                currentMovie.Photo = movie.Photo;

                _db.Entry(currentMovie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return _db.SaveChanges() > 0;
            }
            else if (currentMovie != null && currentMovie.Status == false)
            {
                return "movie has been delete";
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
    public dynamic Delete(int id)
    {
        try
        {
            var currentMovie = _db.Movies.Find(id);
            if (currentMovie != null)
            {
                currentMovie.Status = false;

                _db.Entry(currentMovie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return _db.SaveChanges() > 0;
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
    public dynamic GetItem(int id)
    {
        var movie = _db.Movies.Find(id);
        if (movie != null && movie.Status == true)
        {
            return _db.Movies.Where(m => m.Id == id).Select(m => new
            {
                Id = m.Id,
                Name = m.Name,
                Photo = m.Photo,
                Description = m.Description,
                TimeLast = m.TimeLast,
                DateExpect = m.DateExpect,
                Genre = m.Genre,
                Language = m.Language,
            }).ToList();
        }
        else if (movie != null && movie.Status == false)
        {
            return "movie has been delete";
        }
        else
        {
            return "not found";
        }
    }
    public dynamic Find(int id)
    {
        return _db.Movies.Find(id);
    }


}

