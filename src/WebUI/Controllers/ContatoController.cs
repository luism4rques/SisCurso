using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            return View();
        }

        public IActionResult Index()
        {
            var lstContato = new List<Contato>();
            lstContato.Add(new Contato() { Nome="Maria", SobreNome="Silva", Email="maria@silva.com" });
            lstContato.Add(new Contato() { Nome="José", SobreNome="Silva", Email="jose@silva.com" });

            return View(lstContato);
        }
    }
}