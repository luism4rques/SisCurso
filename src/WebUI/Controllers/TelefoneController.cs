using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DAO;
using DTO;
using WebUI.Models;
using System;

namespace WebUI.Controllers
{
    public class TelefoneController : Controller
    {
        private readonly ITelefoneDAO _telefoneDAO;
        private readonly IMapper _mapper;

        public TelefoneController(ITelefoneDAO telefoneDAO, IMapper mapper)
        {
            _telefoneDAO = telefoneDAO;
            _mapper = mapper;
        }

        public ActionResult Create(int id)
        {
            var telefoneViewModel = new TelefoneViewModel() { ContatoId = id };

            return View(telefoneViewModel);
        }

        [HttpPost]
        public ActionResult Create(TelefoneViewModel telefoneViewModel)
        {
            var telefoneDTO = _mapper.Map<TelefoneDTO>(telefoneViewModel);
            
            try
            {
                _telefoneDAO.Criar(telefoneDTO);
                TempData[Constants.Message.SUCCESS] = "Telefone incluído com sucesso.";
            }
            catch(Exception ex)
            {
                TempData[Constants.Message.ERROR] = ex.Message;
            }

            return RedirectToAction("Details", "Contato", new { id = telefoneViewModel.ContatoId });
        }

        public ActionResult Delete(int contatoId, int id)
        {
            try
            {
                _telefoneDAO.Excluir(id);
                TempData[Constants.Message.SUCCESS] = "Telefone excluído com sucesso.";
            }
            catch(Exception ex)
            {
                TempData[Constants.Message.ERROR] = ex.Message;
            }

            return RedirectToAction("Details", "Contato", new { id = contatoId });
        }

        public IActionResult Update(int id)
        {
            var telefoneDTO = _telefoneDAO.Consultar(id);

            var telefoneViewModel = _mapper.Map<TelefoneViewModel>(telefoneDTO);

            return View(telefoneViewModel);
        }

        [HttpPost]
        public IActionResult Update(TelefoneViewModel telefoneViewModel)
        {
            if(!ModelState.IsValid) {
                return View();
            }

            var telefoneDTO = _mapper.Map<TelefoneDTO>(telefoneViewModel);

            try
            {
                _telefoneDAO.Atualizar(telefoneDTO);
                TempData[Constants.Message.SUCCESS] = "Telefone atualizado com sucesso.";
            }
            catch(Exception ex)
            {
                TempData[Constants.Message.ERROR] = ex.Message;
            }

            return RedirectToAction("Details", "Contato", new { id = telefoneViewModel.ContatoId });
        }
    }
}