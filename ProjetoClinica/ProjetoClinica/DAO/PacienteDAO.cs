using ProjetoClinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DAO {
    public class PacienteDAO {
        private static Entities entities = Singleton.Instance.Entities;

        //ADICIONA PACIENTE
        public static bool AdicionaPaciente(Paciente paciente) {
            try {
                Clinica c = new Clinica();
                c = ClinicaLoginDAO.RetornarClinicaLogada();
                paciente.ClinicaId = c.ClinicaId;
                entities.Pacientes.Add(paciente);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
        //RETORNA LISTA DE PACIENTES DA CLINICA LOGADA - FALTA TERMINAR
        public static List<Paciente> ListaDePacientesDaClinicaLogada() {
            try {
                Clinica clinica = new Clinica();
                clinica = ClinicaLoginDAO.RetornarClinicaLogada();
                return entities.Pacientes.Where(x => x.ClinicaId.Equals(clinica.ClinicaId)).ToList();
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