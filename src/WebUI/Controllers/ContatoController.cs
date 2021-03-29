using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        private List<Contato> lstContato = new List<Contato>();

        public ContatoController()
        {
            lstContato.Add(new Contato() { Id=new Guid("9f10503c-16e4-4f8b-bfaf-4976de1cb418"), Nome="Maria", SobreNome="Silva", Email="maria@silva.com" });
            lstContato.Add(new Contato() { Id=new Guid("8e07cb28-6c6b-48b8-ace3-fe5c8966a4c3"), Nome="José", SobreNome="Silva", Email="jose@silva.com" });
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

        public IActionResult Details(Guid id)
        {
            var contato = lstContato.Find(contato => contato.Id == id);
            return View(contato);
        }
    }
}