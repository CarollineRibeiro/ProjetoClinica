using ProjetoClinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DAO {
    public class ConsultaDAO {
        private static Entities entities = Singleton.Instance.Entities;
        
        //RETORNAR LISTA DE CONSULTAS DA CLINICA LOGADA
        public static List<Consulta> RetornarListaConsultasDaClinicaLogada() {
            try {
                Clinica clinica = new Clinica();
                clinica = ClinicaLoginDAO.RetornarClinicaLogada();
                return entities.Consultas.Where(x => x.Clinica.ClinicaId.Equals(clinica.ClinicaId)).ToList();
            }catch(Exception e) {
                return null;
            }
        }

        //PESQUISAR CONSULTA POR ID
        public static Consulta RetornarConsultaPorId(int id) {
            try {
                return entities.Consultas.Find(id);
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}