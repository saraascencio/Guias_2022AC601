using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace Guias_2022AC601.Servicios
{
    public class AutenticacionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var usuarioId = context.HttpContext.Session.GetInt32("UsuarioId");

            if(usuarioId == null)
            {
                context.Result = new RedirectToActionResult("Autenticar", "usuarios", null);
            }
            base.OnActionExecuting(context);
        }
    }
}
