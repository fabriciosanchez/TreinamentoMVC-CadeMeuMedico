using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exemplo2_CadeMeuMedico.Repositorios;

namespace Exemplo2_CadeMeuMedico.Controllers
{
    public class SistemaController : BaseController
    {
        // GET: Sistema
        public ActionResult Index()
        {
            long ID = RepositorioUsuarios.RetornaIDDoUsuarioLogado();

            if (ID != 0)
            {
                ViewBag.Nome = RepositorioUsuarios.RetornaNomeDoUsuarioComBaseNoID(ID);
            }
            else
            {
                ViewBag.Nome = "Nome não identificado.";
            }
            
            return View();
        }
    }
}