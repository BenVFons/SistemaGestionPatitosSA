using GestionDePersonas.BL;
using GestionDePersonas.UI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestionDePersonas.UI.Controllers
{
    public class LoginController : Controller
    {
        private readonly AdminUsuarios _admin;

        public LoginController(AdminUsuarios admin)
        {
            _admin = admin;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string Password)
        {
            var valido = await _admin.LoginAsync(UserName, Password);

            if (!valido)
            {
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }


    }
}
