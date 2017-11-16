using ProjetoClinica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoClinica.DAO
{
    public class PacienteDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        // BUSCA PACIENTE PELO PACIENTEID
        public static Paciente RetornaPacientePeloId(int? id)
        {

            return entities.Pacientes.Find(id);
        }

        // BUSCA PACIENTE POR CPF
        public static Paciente BuscaPacientePorCPF(Paciente paciente)
        {
            return entities.Pacientes.FirstOrDefault(x => x.PacienteCPF.Equals(paciente.PacienteCPF));
        }
 
    }
}