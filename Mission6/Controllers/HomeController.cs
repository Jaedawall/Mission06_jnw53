using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6.Models;
using System.Linq;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private MovieDbContext MovieContext { get; set; }
        public HomeController(MovieDbContext movie)
        {
            MovieContext = movie;
        }

        //Create the Index controller
        public IActionResult Index()
        {
            return View();
        }

        //Create the MyPodcasts controller
        public IActionResult MyPodcasts()
        {
            return View();
        }

        //Create the MovieForm get controller
        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            return View();
        }

        //Create the MovieForm post controller
        [HttpPost]
        public IActionResult MovieForm(FormResponse response)
        {
            if (ModelState.IsValid)
            {
                MovieContext.Add(response);
                MovieContext.SaveChanges();
                return View("ConfirmationPage");
            }
            else
            {
                ViewBag.Categories = MovieContext.Categories.ToList();

                return View(response);
            }
        }

        //Create the MovieList controller
        public IActionResult MovieList()
        {
            var Movies = MovieContext.responses
                .Include(x => x.Category)
                .OrderBy(x => x.Category)
                .ToList();

            return View(Movies);
        }

        //Create the Edit get controller
        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = MovieContext.Categories.ToList();

            var Movie = MovieContext.responses.Single(x => x.ApplicationId == applicationid);

            return View("MovieForm", Movie);
        }

        //Create the Edit post controller
        [HttpPost]
        public IActionResult Edit(FormResponse movieresponse)
        {
            MovieContext.Update(movieresponse);
            MovieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        //Create the Delete get controller
        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var Movie = MovieContext.responses.Single(x => x.ApplicationId == applicationid);

            return View(Movie);
        }

        //Create the Delete post controller
        [HttpPost]
        public IActionResult Delete(FormResponse response)
        {
            MovieContext.responses.Remove(response);
            MovieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }
    }
}
