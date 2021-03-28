using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }
    }
}