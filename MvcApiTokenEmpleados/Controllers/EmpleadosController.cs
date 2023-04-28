using Microsoft.AspNetCore.Mvc;
using MvcApiTokenEmpleados.Models;
using MvcApiTokenEmpleados.Services;

namespace MvcApiTokenEmpleados.Controllers
{
    public class EmpleadosController : Controller
    {
        private ServiceApiEmpleados service;

        public EmpleadosController(ServiceApiEmpleados service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            string token =
                HttpContext.Session.GetString("TOKEN");
            if(token == null)
            {
                ViewData["MENSAJE"] = "DEBE REALIZAR LOGIN PARA VISUALIZAR DATOS";
                return View();
            }
            else
            {
                List<Empleado> empleados =
                    await this.service.GetEmpleadosAsync(token);
                return View(empleados);
            }
            
        }

        public async Task<IActionResult> Details(int id)
        {
            Empleado emp = await this.service.FindEmpleadoAsync(id);
            return View(emp);
        }
    }
}
