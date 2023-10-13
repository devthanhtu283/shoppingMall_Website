using ABCDMall_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ABCDMall_API.Services;

public class MovieServiceImpl : MovieService
{
    private DatabaseContext _db;
    private IConfiguration configuration;

    public MovieServiceImpl(DatabaseContext db, IConfiguration _configuration)
    {
        _db = db;
        configuration = _configuration;
    }
    public dynamic findAll()
    {
        return _db.Movies.Where(m => m.Status == true).Select(m => new
        {
            Id = m.Id,
            Name = m.Name,
            Photo = configuration["BaseUrl"] + "img/" + m.Photo,
            Description = m.Description,
            TimeLast = m.TimeLast,
            DateExpect = m.DateExpect,
            Genre = m.Genre,
            Language = m.Language,
        }).ToList();
    }

    public dynamic create(Movie movie)
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

    public dynamic delete(int id)
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

    public dynamic update(Movie movie)
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

    public dynamic findbyId(int id)
    {
        var movie = _db.Movies.Find(id);
        if (movie != null && movie.Status == true)
        {
            return _db.Movies.Where(m => m.Id == id).Select(m => new
            {
                Id = m.Id,
                Name = m.Name,
                Photo = configuration["BaseUrl"] + "img/" + m.Photo,
                Description = m.Description,
                TimeLast = m.TimeLast,
                DateExpect = m.DateExpect,
                Genre = m.Genre,
                Language = m.Language,
            }).FirstOrDefault();
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

    public dynamic findbyId2(int id)
    {
        return _db.Movies.AsNoTracking().SingleOrDefault(p => p.Id == id);
    }
   

    public dynamic findByKeyword(string keyword)
    {
        return _db.Movies.Where(m => m.Name.Contains(keyword)).Select(m => new
        {
            Id = m.Id,
            Name = m.Name,
            Photo = m.Photo,
            Description = configuration["BaseUrl"] + "img/" + m.Description,
            TimeLast = m.TimeLast,
            DateExpect = m.DateExpect,
            Genre = m.Genre,
            Language = m.Language,
        }).ToList();
    }
}

