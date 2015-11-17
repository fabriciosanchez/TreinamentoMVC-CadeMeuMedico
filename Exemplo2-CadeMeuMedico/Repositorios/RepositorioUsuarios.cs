using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Exemplo2_CadeMeuMedico.Models;
using Exemplo2_CadeMeuMedico.Repositorios;

namespace Exemplo2_CadeMeuMedico.Repositorios
{
    public class RepositorioUsuarios
    {
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            var SenhaCriptografada = FormsAuthentication.HashPasswordForStoringInConfigFile(Senha, "sha1");

            try
            {
                using (StringConexaoCadeMeuMedicoBD db = new StringConexaoCadeMeuMedicoBD())
                {
                    var QueryAutenticaUsuarios = db.Usuarios.Where(x => x.Login == Login && x.Senha == SenhaCriptografada).SingleOrDefault();

                    if (QueryAutenticaUsuarios == null)
                    {
                        return false;
                    }
                    else
                    {
                       RepositoriosCookies.RegistraCookieAutenticacao(QueryAutenticaUsuarios.IDUsuario, QueryAutenticaUsuarios.Nome);
                       return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Usuarios VerificaSeOUsuarioEstaLogado()
        {
            var Usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
            
            if (Usuario == null)
            {
                return null;
            }
            else
            {
                long IDUsuario = Convert.ToInt64(RepositorioCriptografia.Descriptografar(Usuario.Values["IDUsuario"]));

                var UsuarioRetornado = RecuperaUsuarioPorID(IDUsuario);
                return UsuarioRetornado;

            }
        }

        public static Usuarios RecuperaUsuarioPorID(long IDUsuario)
        {
            try
            {
                using (StringConexaoCadeMeuMedicoBD db = new StringConexaoCadeMeuMedicoBD())
                {
                    var Usuario = db.Usuarios.Where(u => u.IDUsuario == IDUsuario).SingleOrDefault();
                    return Usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool VerificaSeOUsuarioEstaLogadoComBaseNoCookie()
        {
            var Cookie = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];

            if(Cookie == null)
            {
                return false;
            }
            else
            {
                if(RepositorioCriptografia.Descriptografar(Cookie.Values["StatusLogon"]) == "1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static bool SairDoSistema()
        {
            try
            {
                var Cookie = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];
                Cookie.Expires = DateTime.Now.AddDays(-1d);
                HttpContext.Current.Response.Cookies.Add(Cookie);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string RetornaNomeDoUsuarioComBaseNoID(long IDUsuario)
        {
            var Cookie = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];

            if(Cookie == null)
            {
                return null;
            }
            else
            {
                return RepositorioCriptografia.Descriptografar(Cookie.Values["Nome"]);
            }
        }

        public static long RetornaIDDoUsuarioLogado()
        {
            var Usuario = HttpContext.Current.Request.Cookies["UserCookieAuthentication"];

            if (Usuario == null)
            {
                return 0;
            }
            else
            {
                long IDUsuario = Convert.ToInt64(RepositorioCriptografia.Descriptografar(Usuario.Values["IDUsuario"]));
                return IDUsuario;
            }
        }
    }
}