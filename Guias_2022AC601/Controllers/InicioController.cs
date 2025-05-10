using Microsoft.AspNetCore.Mvc;
using Guias_2022AC601.Servicios;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
using Microsoft.Data.SqlClient;
using Guias_2022AC601.Models;

namespace Guias_2022AC601.Controllers
{
    public class InicioController : Controller
    {

        private IConfiguration _configuration;
        private readonly usuariosDBcontext _context;

        public InicioController (usuariosDBcontext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

   
        public IActionResult Index()
        {
            correo enviarCorreo = new correo(_configuration);

            enviarCorreo.enviar("acaestariamicorreo@catolica.edu.sv",
                                "Prueba Asunto",
                                "Esta es una prueba de correo");

           
            return View();
        }
 
      
    }
}
