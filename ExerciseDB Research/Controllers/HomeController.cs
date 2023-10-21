using ExerciseDB_Research.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ExerciseDB_Research.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static ExerciseModel _exercise;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index(ExerciseModel _exercise)
        {
            _exercise = new ExerciseModel();
            return View(_exercise);
        }

        public static void requestDataUpdate(string userInput)
        {
            _exercise.updateResult(userInput);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}