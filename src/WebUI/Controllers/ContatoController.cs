using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using DAL;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        private List<Contato> lstContato = new List<Contato>();

        public ContatoController()
        {
            lstContato.Add(new Contato() { Id=1, Nome="Maria", SobreNome="Silva", Email="maria@silva.com" });
            lstContato.Add(new Contato() { Id=2, Nome="José", SobreNome="Silva", Email="jose@silva.com" });
        }

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
            return View(lstContato);
        }

        public IActionResult Details(int id)
        {
            var contato = lstContato.Find(contato => contato.Id == id);

            return View(contato);
        }
    }
}