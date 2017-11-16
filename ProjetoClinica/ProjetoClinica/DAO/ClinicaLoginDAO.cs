using ProjetoClinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DAO
{
    public class ClinicaLoginDAO
    {
        private static Entities entities = Singleton.Instance.Entities;
        //RETORNAR CLINICA LOGADO
        public static Clinica RetornarClinicaLogada() {
            try {
                foreach (ClinicaLogin temp in RetornarListaClinicasLogadas()) {
                    if (temp.ClinicaLoginSessao.Equals(RetornarIdSessao())) {
                        foreach (Clinica clinica in RetornarListaClinicas()) {
                            if (temp.Login.Equals(clinica.Login)) {
                                return clinica;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception e) {
                return null;
            }
        }

        //RETORNA LISTA DE CLINICAS
        public static List<Clinica> RetornarListaClinicas() {
            try {
                return entities.Clinicas.ToList();
            }catch(Exception e) {
                return null;
            }
        }

        //RETORNA OU GERA ID PRA SESSão
        public static string RetornarIdSessao() {
            if (HttpContext.Current.Session["Sessao"] == null) {
                //ESTE GUID GERA UMA SERIE ALFANUMERICA UNICA PARA CADA CARRINHO
                Guid guid = Guid.NewGuid();
                HttpContext.Current.Session["Sessao"] = guid.ToString();
            }
            return HttpContext.Current.Session["Sessao"].ToString();
        }

        //RETORNA LISTA DE CLINICAS LOGADAS
        public static List<ClinicaLogin> RetornarListaClinicasLogadas() {
            try {
                return entities.ClinicaLogins.ToList();
            }catch(Exception e) {
                return null;
            }
        } 
    }
}