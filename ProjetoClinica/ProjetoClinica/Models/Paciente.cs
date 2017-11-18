using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoClinica.Models
{
    [Table("Pacientes")]
    public class Paciente
    {
        [Key]
        public int PacienteId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Nome")]
        public string PacienteNome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "CPF")]
        public string PacienteCPF { get; set; }

        public int ClinicaId { get; set; }
    }
}