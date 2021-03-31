using System.Collections.Generic;
using DAL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        private ContatoDAO _contatoDAO;

        public ContatoController()
        {
            _contatoDAO = new ContatoDAO();
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
            
            _contatoDAO.Criar(contatoDTO);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(Contato contato)
        {
            var contatoDTO = new ContatoDTO 
            { 
                Id = contato.Id,
                Nome = contato.Nome, 
                SobreNome = contato.SobreNome,
                Email = contato.Email
            };
            
            _contatoDAO.Atualizar(contatoDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var lstContatoDTO = _contatoDAO.Consultar();
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

        public IActionResult Delete(int id)
        {
            _contatoDAO.Excluir(id);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var contatoDTO = _contatoDAO.Consultar(id);

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