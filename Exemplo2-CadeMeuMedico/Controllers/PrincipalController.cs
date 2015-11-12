using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exemplo2_CadeMeuMedico.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index()
        {
            int Valor;

            if (RouteData.Values["id"] != null)
            {
                Valor = Convert.ToInt16(RouteData.Values["id"].ToString());
                if (Valor == 1)
                {
                    ViewBag.Mensagem = "Bom dia!";
                }
                else
                {
                    ViewBag.Mensagem = "Boa noite";
                } 
            }
            else
            {
                ViewBag.Mensagem = "Nenhum parâmetro informado.";
            }

            return View();
        }

        public ActionResult pesquisa()
        {
            string PrimeiraParte;

            if (RouteData.Values["fabricio"] != null)
            {
                PrimeiraParte = RouteData.Values["fabricio"].ToString();

                if (PrimeiraParte != "fabricio")
                {
                    ViewBag.Mensagem = "Rota incorreta";
                }
                else
                {
                    ViewBag.Mensagem = "Rota validada com sucesso";
                } 
            }

            return View();
        }
    }
}