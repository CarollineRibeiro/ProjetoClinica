using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoClinica.Models
{
    public class Entities : DbContext
    {
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<ClinicaLogin> ClinicaLogins { get; set; }
    }
}