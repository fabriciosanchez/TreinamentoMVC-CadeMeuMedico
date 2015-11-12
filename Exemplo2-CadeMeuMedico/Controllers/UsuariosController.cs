using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo2_CadeMeuMedico.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Login()
        {
            return View();
        }
    }
}