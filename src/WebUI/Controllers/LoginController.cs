using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private HttpContextAccessor _context;
        public LoginController(HttpContextAccessor context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Login()
        {
            var lstClaim = new List<Claim>();
            lstClaim.Add(new Claim("BeBe","Cagado"));
            var claimsIdentity = new ClaimsIdentity(lstClaim, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            var authProperties = new AuthenticationProperties { ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60), IsPersistent = true };
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authProperties);
            return View();
        }

        [HttpGet]
        [Authorize(Policy = "EmployeeOnly")]
        public ActionResult Autorizado()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Acessonegado()
        {
            var context = _context.HttpContext;
            return View();
        }


    }
}