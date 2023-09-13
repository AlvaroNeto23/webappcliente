using Microsoft.AspNetCore.Mvc;

namespace WebAppPresentation.Controllers
{
    public class ClienteCadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastrarComJquery()
        {
            return View();
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
    }
}
