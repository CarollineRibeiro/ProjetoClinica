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

        // BUSCANDO CONSULTA POR DATA
        public static Consulta BuscandoConsultaPorData(Consulta consulta)
        {
            return entities.Consultas.FirstOrDefault(x => x.DataConsulta.Equals(consulta.DataConsulta));
        }

        // BUSCANDO CONSULTA POR PACIENTE
        public static Consulta BuscandoConsultaPorPaciente(Consulta consulta)
        {
            return entities.Consultas.FirstOrDefault(x => x.PacienteId.Equals(consulta.PacienteId));
        }
    }
}