using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Rosenlund.Models;
using System.Diagnostics;

namespace Mission06_Rosenlund.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context; // Database "Instance"
        public HomeController(MovieContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About() // Get to know Joel page
        {
            return View();
        }

        public IActionResult Confirmation() // Submission confirmation
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie() // Form page
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View(new Movie());
        }

        [HttpPost] // Form submission
        public IActionResult AddMovie(Movie movie)
        {
            if (ModelState.IsValid)  // Check form data
            {
            _context.Movies.Add(movie); // Add to the database
            _context.SaveChanges();

            return View("Confirmation");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(movie);
            }
            
        }

        public IActionResult Collection()
        {
            var movies = _context.Movies
                .Include("Category") // Join to display category name
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var toEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddMovie", toEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid) // Check for valid data
            {
                _context.Movies.Update(movie);
                _context.SaveChanges();

                return RedirectToAction("Collection");
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View("AddMovie", movie);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var toDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View("ConfirmDelete", toDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
