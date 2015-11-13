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
                       RepositoriosCookies.RegistraCookieAutenticacao(QueryAutenticaUsuarios.IDUsuario);
                       return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}