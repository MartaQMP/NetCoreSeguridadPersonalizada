using Microsoft.AspNetCore.Mvc;
using NetCoreSeguridadPersonalizada.Filters;

namespace NetCoreSeguridadPersonalizada.Controllers
{
    public class UsuarioController : Controller
    {
        [AuthorizeUsers]
        public IActionResult Perfil()
        {
            return View();
        }
    }
}
