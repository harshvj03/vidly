using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        DatabaseContext db = new DatabaseContext();
        // GET: Movies
        public ActionResult Random()
        {
            var movies = db.Movie.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            //var movies = GetMovies();
            var movie = db.Movie.Include(m => m.Genre).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();


            var viewModel = new MovieFormModel
            {
                movie = movie,
                Genres = db.Genre.ToList()

            };
            return View("MovieForm",viewModel);
        }

        public ActionResult New()
        {
            var genres = db.Genre.ToList();

            var viewModel = new MovieFormModel
            {
                  Genres = genres
        };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if(movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                db.Movie.Add(movie);
            }
            else
            {
                var movieInDb = db.Movie.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }

            db.SaveChanges();
            return RedirectToAction("Random","Movies");
        }
       
    }
}