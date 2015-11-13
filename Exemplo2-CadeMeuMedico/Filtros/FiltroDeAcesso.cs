using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exemplo2_CadeMeuMedico.Repositorios;

namespace Exemplo2_CadeMeuMedico.Filtros
{
    [HandleError]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
    public class FiltroDeAcesso : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext FiltroDeContexto)
        {
            var Controller = FiltroDeContexto.ActionDescriptor.ControllerDescriptor.ControllerName;
            var Action = FiltroDeContexto.ActionDescriptor.ActionName;

            if (Controller != "Home" || Action != "Index")
            {
                if (RepositorioUsuarios.VerificaSeOUsuarioEstaLogado() == null)
                {
                    FiltroDeContexto.RequestContext.HttpContext.Response.Redirect("/Usuarios/Login?Url=" + FiltroDeContexto.HttpContext.Request.Url.LocalPath);
                }
            }
        }
    }
}