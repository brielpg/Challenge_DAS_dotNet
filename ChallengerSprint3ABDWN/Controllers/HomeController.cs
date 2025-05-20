using Microsoft.AspNetCore.Mvc;

namespace ABDWNSprint1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
