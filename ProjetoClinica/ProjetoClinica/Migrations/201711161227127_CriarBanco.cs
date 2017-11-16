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
                        PacienteId = c.Int(nullable: false),
                        DataConsulta = c.DateTime(nullable: false),
                        Clinica_ClinicaId = c.Int(),
                    })
                .PrimaryKey(t => t.ConsultaId)
                .ForeignKey("dbo.Clinicas", t => t.Clinica_ClinicaId)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId)
                .Index(t => t.Clinica_ClinicaId);
            
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
            DropForeignKey("dbo.Consultas", "PacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Consultas", "Clinica_ClinicaId", "dbo.Clinicas");
            DropIndex("dbo.Consultas", new[] { "Clinica_ClinicaId" });
            DropIndex("dbo.Consultas", new[] { "PacienteId" });
            DropTable("dbo.Pacientes");
            DropTable("dbo.Consultas");
            DropTable("dbo.Clinicas");
            DropTable("dbo.ClinicaLogins");
        }
    }
}
