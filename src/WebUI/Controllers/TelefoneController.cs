using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DAO;
using DTO;
using WebUI.Models;

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
            
            _telefoneDAO.Criar(telefoneDTO);

            return RedirectToAction("Details", "Contato", new { id = telefoneViewModel.ContatoId });
        }
    }
}