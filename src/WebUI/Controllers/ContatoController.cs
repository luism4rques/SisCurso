using System.Collections.Generic;
using DAO;
using DTO;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

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
            var contatoDTO = new ContatoDTO 
            { 
                Nome = contato.Nome, 
                SobreNome = contato.SobreNome,
                Email = contato.Email
            };
            
            var contatoDAO = new ContatoDAO();
            contatoDAO.Criar(contatoDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var contatoDAO = new ContatoDAO();
            var lstContatoDTO = contatoDAO.Consultar();

            var lstContato = new List<Contato>();

            foreach(var dto in lstContatoDTO)
            {
                lstContato.Add(new Contato()
                { 
                    Id = dto.Id, 
                    Nome = dto.Nome, 
                    SobreNome = dto.SobreNome, 
                    Email = dto.Email 
                });
            }

            return View(lstContato);
        }

        public IActionResult Details(int id)
        {
            var contatoDAO = new ContatoDAO();
            var contatoDTO = contatoDAO.Consultar(id);

            var contato = new Contato()
            { 
                Id = contatoDTO.Id, 
                Nome = contatoDTO.Nome, 
                SobreNome = contatoDTO.SobreNome, 
                Email = contatoDTO.Email 
            };

            return View(contato);
        }
    }
}