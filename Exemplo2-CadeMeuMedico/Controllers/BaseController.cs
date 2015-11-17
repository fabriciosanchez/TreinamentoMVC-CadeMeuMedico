using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exemplo2_CadeMeuMedico.Filtros;

namespace Exemplo2_CadeMeuMedico.Controllers
{
    [FiltroDeAcesso]
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}