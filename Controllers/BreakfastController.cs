using MGQSBreakfast.Contracts.Services;
using MGQSBreakfast.Models;
using Microsoft.AspNetCore.Mvc;

namespace MGQSBreakfast.Controllers
{
    [Route("[controller]")]
    public class BreakfastController : Controller
    {
        List<BreakfastViewModel> breakfasts = new ()
    {
        new BreakfastViewModel(){Id = 1, Name = "Jollof Rice"},
        new BreakfastViewModel(){Id = 2, Name = "Fried Rice"},
        new BreakfastViewModel(){Id = 3, Name = "Coconut Rice"},
        new BreakfastViewModel(){Id = 4, Name = "White Rice"},
        new BreakfastViewModel(){Id = 4, Name = "Concotion Rice"}
    };
        private readonly ILogger<BreakfastController> _logger;

        public BreakfastController(ILogger<BreakfastController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BreakfastMenu()
        {
            var breakfast = breakfasts.ToList();
            return View(breakfasts);
        }
    [HttpGet("{id}")]
        public IActionResult BrakfastDetail(int id)
        {
            var breakfast = breakfasts.Where(x => x.Id == id).SingleOrDefault();
            return View(breakfast);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}