namespace ProjetoClinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClinicaLogins",
                c => new
                    {
                        ClinicaLoginId = c.Int(nullable: false, identity: true),
                        Login = c.String(),
                        ClinicaLoginSessao = c.String(),
                    })
                .PrimaryKey(t => t.ClinicaLoginId);
            
            CreateTable(
                "dbo.Clinicas",
                c => new
                    {
                        ClinicaId = c.Int(nullable: false, identity: true),
                        ClinicaNome = c.String(),
                        ClinicaMedico = c.String(),
                        Login = c.String(),
                        Senha = c.String(),
                    })
                .PrimaryKey(t => t.ClinicaId);
            
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        ConsultaId = c.Int(nullable: false, identity: true),
                        DataConsulta = c.DateTime(nullable: false),
                        Clinica_ClinicaId = c.Int(),
                        Paciente_PacienteId = c.Int(),
                    })
                .PrimaryKey(t => t.ConsultaId)
                .ForeignKey("dbo.Clinicas", t => t.Clinica_ClinicaId)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_PacienteId)
                .Index(t => t.Clinica_ClinicaId)
                .Index(t => t.Paciente_PacienteId);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        PacienteId = c.Int(nullable: false, identity: true),
                        PacienteNome = c.String(nullable: false),
                        PacienteCPF = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PacienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "Paciente_PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Consultas", "Clinica_ClinicaId", "dbo.Clinicas");
            DropIndex("dbo.Consultas", new[] { "Paciente_PacienteId" });
            DropIndex("dbo.Consultas", new[] { "Clinica_ClinicaId" });
            DropTable("dbo.Pacientes");
            DropTable("dbo.Consultas");
            DropTable("dbo.Clinicas");
            DropTable("dbo.ClinicaLogins");
        }
    }
}
