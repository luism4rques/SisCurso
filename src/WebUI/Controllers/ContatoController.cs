using System.Collections.Generic;
using AutoMapper;
using DAL;
using DTO;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoDAO _contatoDAO;
        private readonly IMapper _mapper;

        public ContatoController(IContatoDAO contatoDAO, IMapper mapper)
        {
            _contatoDAO = contatoDAO;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContatoViewModel contatoViewModel)
        {
            if(!ModelState.IsValid) {
                return View();
            }

            var contatoDTO = _mapper.Map<ContatoDTO>(contatoViewModel);
            // var contatoDTO = new ContatoDTO 
            // { 
            //     Nome = contatoViewModel.Nome, 
            //     SobreNome = contatoViewModel.SobreNome,
            //     Email = contatoViewModel.Email
            // };
            
            _contatoDAO.Criar(contatoDTO);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(ContatoViewModel contatoViewModel)
        {
            if(!ModelState.IsValid) {
                return View();
            }

            var contatoDTO = _mapper.Map<ContatoDTO>(contatoViewModel);

            // var contatoDTO = new ContatoDTO 
            // { 
            //     Id = contatoViewModel.Id,
            //     Nome = contatoViewModel.Nome, 
            //     SobreNome = contatoViewModel.SobreNome,
            //     Email = contatoViewModel.Email
            // };
            
            _contatoDAO.Atualizar(contatoDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            var lstContatoDTO = _contatoDAO.Consultar();
            var lstContatoViewModel = new List<ContatoViewModel>();

            foreach(var dto in lstContatoDTO)
            {
                lstContatoViewModel.Add(_mapper.Map<ContatoViewModel>(dto));

                // lstContatoViewModel.Add(new ContatoViewModel()
                // { 
                //     Id = dto.Id, 
                //     Nome = dto.Nome, 
                //     SobreNome = dto.SobreNome, 
                //     Email = dto.Email 
                // });
            }

            return View(lstContatoViewModel);
        }

        public IActionResult Delete(int id)
        {
            _contatoDAO.Excluir(id);

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var contatoDTO = _contatoDAO.Consultar(id);

            var contatoViewModel = _mapper.Map<ContatoViewModel>(contatoDTO);
            // var contatoViewModel = new ContatoViewModel()
            // { 
            //     Id = contatoDTO.Id, 
            //     Nome = contatoDTO.Nome, 
            //     SobreNome = contatoDTO.SobreNome, 
            //     Email = contatoDTO.Email 
            // };

            return View(contatoViewModel);
        }
    }
}