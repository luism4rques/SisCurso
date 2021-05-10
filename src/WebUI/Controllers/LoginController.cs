using System;
using DAO;
using DTO;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using Crypt = BCrypt.Net.BCrypt;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioDAO _usuarioDAO;

        public LoginController(IUsuarioDAO usuarioDAO)
        {
            _usuarioDAO = usuarioDAO;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid) {
                return View();
            }

            if(_usuarioDAO.Consultar(registerViewModel.Email) != null)
            {
                TempData[Constants.Message.ERROR] = "O e-mail já está sendo utilizado por outro usuário.";
                return View();
            }

            try
            {
                _usuarioDAO.Criar(new UsuarioDTO() { Email = registerViewModel.Email, 
                    Senha = Crypt.HashPassword(registerViewModel.Password) });
                TempData[Constants.Message.SUCCESS] = "Usuário criado com sucesso.";
            }
            catch(Exception ex)
            {
                TempData[Constants.Message.ERROR] = ex.Message;
            }

            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid) {
                return View();
            }

            var usuarioDTO = _usuarioDAO.Consultar(loginViewModel.Email);

            if(usuarioDTO == null || !Crypt.Verify(loginViewModel.Password, usuarioDTO.Senha))
            {
                TempData[Constants.Message.ERROR] = "O e-mail ou senha inválidos.";
                return View();
            }

            TempData[Constants.Message.SUCCESS] = "Usuário autenticado com sucesso.";
            return View();
        }
    }
}