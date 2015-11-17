using Exemplo2_CadeMeuMedico.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Exemplo2_CadeMeuMedico.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Login()
        {
            //ViewBag.Senha = FormsAuthentication.HashPasswordForStoringInConfigFile("123", "sha1");
            return View();
        }

        [HttpGet]
        public JsonResult AutenticacaoDeUsuario(string Login, string Senha)
        {
            if (RepositorioUsuarios.AutenticarUsuario(Login, Senha))
            {
                long ID = RepositorioUsuarios.RetornaIDDoUsuarioLogado();
                string Nome;

                if (ID != 0)
                {
                    Nome = RepositorioUsuarios.RetornaNomeDoUsuarioComBaseNoID(ID);
                }
                else
                {
                    Nome = "Nome não identificado.";
                }
                return Json(new { OK = true, Mensagem = "<img src='/Content/Imagens/ajax-loader.gif' border='0' />&nbsp;Achamos você " + Nome + ". Carregando seus recursos..." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { OK = false, Mensagem = "Usuário não encontrando. Tente novamente." }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Sair()
        {
            bool Resultado = RepositorioUsuarios.SairDoSistema();

            if (Resultado)
            {
                ViewBag.Mensagem = "Você foi desconectado com sucesso.";
                ViewBag.Mensagem2 = "Obrigado por utilizar o sistema.";
            }
            else
            {
                ViewBag.Mensagem = "Erro ao tentar desconectar.";
                ViewBag.Mensagem2 = "Por favor, tente novamente mais tarde. Se o erro persistir, comunique o administrador do sistema.";
            }

            return View();
        }
    }
}