using System;
using System.Security.Claims;
using DAO;
using DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
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

        public ActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnURL = returnUrl });
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

            Autenticar();

            if (Url.IsLocalUrl(loginViewModel.ReturnURL))
            {
                return Redirect(loginViewModel.ReturnURL);
            }
            
            return RedirectToAction("Index", "Home");
        }

        private async void Autenticar()
        {
            var claimsIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authProperties = new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddSeconds(10), IsPersistent = true };
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
        }
    }
}