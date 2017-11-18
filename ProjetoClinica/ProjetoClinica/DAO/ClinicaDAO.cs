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
                login.ClinicaLoginSessao = ClinicaLoginDAO.RetornarIdSessao();
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

        //PESQUISA LOGIN REPETIDO
        public static Clinica LoginExistente(Clinica clinica) {
            try {
                return entities.Clinicas.FirstOrDefault(x => x.Login.Equals(clinica.Login));
            }
            catch (Exception e) {
                return null;
            }
        }

        //LISTA DE CLINICAS
        public static List<Clinica> ListaDeClinicas() {
            try {
                return entities.Clinicas.ToList();
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}