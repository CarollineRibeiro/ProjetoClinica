using ProjetoClinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DAO
{
    public class ClinicaDAO
    {

        private static Entities entities = Singleton.Instance.Entities;
        public static bool AdicionarLogin(Clinica clinica)
        {
            try
            {
                ClinicaLogin login = new ClinicaLogin();
                login.Login = clinica.Login;
                login.ClinicaLoginSessao = RetornarIdSessao();
                entities.ClinicaLogins.Add(login);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //PESQUISA LOGIN DO USUARIO
        public static Clinica LoginUsuario(Clinica clinica)
        {
            try
            {
                foreach (Clinica temp in entities.Clinicas.ToList())
                {
                    if (temp.Login.Equals(clinica.Login))
                    {
                        if (temp.Senha.Equals(clinica.Senha))
                        {
                            return temp;
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //RETORNA OU GERA ID PRA SESSão
        public static string RetornarIdSessao()
        {
            if (HttpContext.Current.Session["Sessao"] == null)
            {
                //ESTE GUID GERA UMA SERIE ALFANUMERICA UNICA PARA CADA CARRINHO
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["Sessao"] = guid.ToString();
            }
            return HttpContext.Current.Session["Sessao"].ToString();
        }


        //RETORNAR CLINICA LOGADO
        public static Clinica RetornarUsuarioLogado()
        {
            try
            {
                foreach (ClinicaLogin temp in LoginUserDAO.RetornarListaLoginsUsers())
                {
                    if (temp.LoginUserSessao.Equals(LoginUserDAO.RetornarIdSessao()))
                    {
                        foreach (Usuario user in ListarUsuarios())
                        {
                            if (temp.LoginUserUsuario.UsuarioId.Equals(user.UsuarioId))
                            {
                                return user;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}