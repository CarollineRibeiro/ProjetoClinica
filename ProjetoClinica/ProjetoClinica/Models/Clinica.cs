using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoClinica.Models
{
    [Table("Clinicas")]
    public class Clinica
    {
        [Key]
        public int ClinicaId { get; set; }

        [Display(Name = "Nome da Clínica")]
        public string ClinicaNome { get; set; }

        [Display(Name = "Nome do Médico")]
        public string ClinicaMedico { get; set; }

        [Display(Name = "Login")]
        public string Login { get; set; }

        [Display(Name = "Senha")]
        public string Senha { get; set; }

        public List<Paciente> Pacientes { get; set; }

    }
}