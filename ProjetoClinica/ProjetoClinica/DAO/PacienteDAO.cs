using ProjetoClinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DAO {
    public class PacienteDAO {
        private static Entities entities = Singleton.Instance.Entities;

        //RETORNA LISTA DE PACIENTES DA CLINICA LOGADA - FALTA TERMINAR
        public static List<Paciente> ListaDePacientesDaClinicaLogada() {
            try {
                Clinica clinica = new Clinica();
                clinica = ClinicaLoginDAO.RetornarClinicaLogada();
                return null;
            }
            catch (Exception e) {
                return null;
            }
        }

        //RETORNA LISTA DE PACIENTES
        public static List<Paciente> ListaDePacientes() {
            try {
                return entities.Pacientes.ToList();
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}