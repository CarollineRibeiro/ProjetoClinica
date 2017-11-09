using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoClinica.Models
{
    [Table("ClinicaLogins")]
    public class ClinicaLogin
    {
        [Key]
        public int ClinicaLoginId { get; set; }
        public string Login { get; set; }
        public string ClinicaLoginSessao { get; set; }
    }
}