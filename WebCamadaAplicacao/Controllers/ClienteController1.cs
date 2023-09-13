using Microsoft.AspNetCore.Mvc;

namespace WebCamadaAplicacao.Controllers
{
    public class ClienteController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
