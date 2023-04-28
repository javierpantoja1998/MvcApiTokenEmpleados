using Microsoft.AspNetCore.Mvc;
using MvcApiTokenEmpleados.Services;

namespace MvcApiTokenEmpleados.Controllers
{
    public class ManagedController : Controller
    {
        private ServiceApiEmpleados service;

        public ManagedController(ServiceApiEmpleados service)
        {
            this.service = service;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            string token =
                await this.service.GetTokenAsync(username, password);
            if(token == null)
            {
                ViewData["MENSAJE"] = "Usuario/Password incorrectos";
            }
            else
            {
                ViewData["MENSAJE"] = "BIENVENIDO AMIGO ! :) ESTAS EN MI APP";
                HttpContext.Session.SetString("TOKEN", token);
            }
            return View();
        }
    }
}
