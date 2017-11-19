namespace ProjetoClinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadoClinicaAoPaciente : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pacientes", "Clinica_ClinicaId", c => c.Int());
            CreateIndex("dbo.Pacientes", "Clinica_ClinicaId");
            AddForeignKey("dbo.Pacientes", "Clinica_ClinicaId", "dbo.Clinicas", "ClinicaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pacientes", "Clinica_ClinicaId", "dbo.Clinicas");
            DropIndex("dbo.Pacientes", new[] { "Clinica_ClinicaId" });
            DropColumn("dbo.Pacientes", "Clinica_ClinicaId");
        }
    }
}
