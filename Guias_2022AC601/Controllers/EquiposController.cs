using Guias_2022AC601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Guias_2022AC601.Controllers
{
    public class EquiposController : Controller
    {
        private readonly usuariosDBcontext _context;

        public EquiposController(usuariosDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var listaDeMarcas = (from m in _context.marcas
                                 select m).ToList();
            ViewData["listadoDeMarcas"] = new SelectList(listaDeMarcas, "id_marcas", "nombre_marca");

            var listaDeTipos = (from m in _context.tipo_equipo
                                 select m).ToList();
            ViewData["listadoDeTipos"] = new SelectList(listaDeTipos, "id_tipo_equipo", "descripcion");

            var listaDeEstados = (from m in _context.estados_equipo
                                select m).ToList();
            ViewData["listadoDeEstados"] = new SelectList(listaDeEstados, "id_estados_equipo", "descripcion");

            ViewData["estado"] = false; // entonces cuando si se marca la casilla inactivo, saldrá como true el estado
                                        // de la tabla equipos de la bd

            var listadoDeEquipos = (from e in _context.equipos
                                    join m in _context.marcas on e.marca_id equals m.id_marcas
                                    
                                    select new
                                    {
                                        nombre = e.nombre,
                                        descripcion = e.descripcion,
                                        marca_id = e.marca_id,
                                        marca_nombre = m.nombre_marca,
                                       
                                      
                                    }).ToList();
            ViewData["listadoEquipo"] = listadoDeEquipos;
            return View();
        }

        public IActionResult CrearEquipos(equipos nuevoEquipo)
        {
            _context.Add(nuevoEquipo);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
