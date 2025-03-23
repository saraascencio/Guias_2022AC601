using Guias_2022AC601.Models;
using Guias_2022AC601.Servicios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Guias_2022AC601.Controllers
{
    public class usuariosController : Controller

    {
        private readonly ILogger<usuariosController> _logger;
        private readonly usuariosDBcontext _usuariosDBContexto;
        public usuariosController(ILogger<usuariosController> logger, usuariosDBcontext usuariosDBContexto)
        {
            _usuariosDBContexto = usuariosDBContexto;
            _logger = logger;
        }

        [Autenticacion]
        public IActionResult Index()
        {
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            var tipoUsuario = HttpContext.Session.GetString("TipoUsuario");
            var nombreUsuario = HttpContext.Session.GetString("Nombre");
            if (usuarioId == null)
            {
                return RedirectToAction("Autenticar", "usuarios");
            }
            ViewBag.nombre = nombreUsuario;
            ViewData["tipoUsuario"] = tipoUsuario;
            return View();
        }

        public IActionResult Autenticar()
        {
            ViewData["ErrorMessage"] = "";
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Autenticar(string txtUsuario, string txtClave)
        {
            var usuario = (from u in _usuariosDBContexto.usuarios
                           where u.email == txtUsuario
                           && u.contrasenia == txtClave
                           && u.activo == 'S'
                           && u.bloqueado == 'N'
                           select u).FirstOrDefault();

            if (usuario != null)
            {
                HttpContext.Session.SetInt32("UsuarioId", usuario.id_usuario);
                HttpContext.Session.SetString("TipoUsuario", usuario.tipo_usuario);
                HttpContext.Session.SetString("Nombre", usuario.nombre);

                return RedirectToAction("Index", "usuarios");
            }
            ViewData["ErrorMessage"] = "Error, usuario inválido";
            return View();
        }

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
