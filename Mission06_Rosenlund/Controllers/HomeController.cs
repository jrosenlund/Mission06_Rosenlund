using Microsoft.AspNetCore.Mvc;
using Mission06_Rosenlund.Models;
using System.Diagnostics;

namespace Mission06_Rosenlund.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _context;
        public HomeController(MovieContext temp) // Constructor
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            return View();
        }

        [HttpPost] // Form submission
        public IActionResult AddMovie(Movie movie)
        {
            _context.Movies.Add(movie); // Add to the database
            _context.SaveChanges();

            return View("AddMovie");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
