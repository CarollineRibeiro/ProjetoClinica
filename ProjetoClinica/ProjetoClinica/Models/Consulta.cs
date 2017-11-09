using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoClinica.Models
{
    [Table("Consultas")]
    public class Consulta
    {
        [Key]
        public int ConsultaId { get; set; }
        public Paciente Paciente { get; set; }
        public Clinica Clinica { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório!")]
        [Display(Name = "Data da Consulta")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataConsulta { get; set; }
    }
}