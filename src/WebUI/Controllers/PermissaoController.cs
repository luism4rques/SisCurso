using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class PermissaoController : Controller
    {
        public PermissaoController()
        {

        }

        public IActionResult Create()
        {
            var permissaoDAO = new DAO.SQLite.PermissaoDAO();
            var usuarioDAO = new DAO.SQLite.UsuarioDAO();

            var lst = permissaoDAO.Consultar();

            var vm = new PermissaoViewModel();
            foreach(var item in lst){
                vm.Permissao.Add(new OptionItem { Id = item.Id, Titulo = item.Titulo });
            }

            var lstUsuario = usuarioDAO.Consultar();
            foreach(var item in lstUsuario){
                vm.Usuario.Add(new OptionItem { Id = item.Id, Titulo = item.Email });
            }

            vm.Contato_Consultar = "s";
            return View(vm);
        }
    }
}