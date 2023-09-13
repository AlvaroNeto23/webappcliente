using Microsoft.AspNetCore.Mvc;

namespace WebAppPresentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
