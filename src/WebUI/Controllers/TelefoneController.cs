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
    }
}