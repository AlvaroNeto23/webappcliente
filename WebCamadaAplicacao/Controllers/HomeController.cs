using Microsoft.AspNetCore.Mvc;

namespace WebCamadaAplicacao.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
