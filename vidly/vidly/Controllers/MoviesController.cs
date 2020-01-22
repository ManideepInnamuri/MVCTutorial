using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using VidlyAPI.Models;
using VidlyAPI.ViewModels;

namespace vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context = null;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies.Random
        public ActionResult Random()
        {
            var movie = _context.Movies.Include(m => m.Genere).ToList();
            return View(movie);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genere).SingleOrDefault(p => p.Id == id);
            return View(movie);
        }

        public ActionResult New()
        {
            return View("MovieForm", new RandomMovieViewModel() { Movie = new Movie() { ReleaseDate = new DateTime() }, Generes = _context.Generes.ToList() });
        }
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(p => p.Id == id);
            return View("MovieForm", new RandomMovieViewModel() { Movie = movie, Generes = _context.Generes.ToList() });
        }

        public ActionResult Save(Movie movie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("MovieForm", new RandomMovieViewModel() { Movie = movie, Generes = _context.Generes.ToList() });
                }

                if (movie.Id == 0)
                {
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDb = _context.Movies.SingleOrDefault(p => p.Id == movie.Id);
                    movieInDb.Name = movie.Name;
                    movieInDb.ReleaseDate = movie.ReleaseDate;
                    movieInDb.GenereId = movie.GenereId;
                    movieInDb.NumberinStock = movie.NumberinStock;
                }
                _context.SaveChanges();
                return RedirectToAction("Random", "Movies");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}