namespace ProjetoClinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arrumarModelConsulta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consultas", "Paciente_PacienteId", "dbo.Pacientes");
            DropIndex("dbo.Consultas", new[] { "Paciente_PacienteId" });
            RenameColumn(table: "dbo.Consultas", name: "Paciente_PacienteId", newName: "PacienteId");
            AlterColumn("dbo.Consultas", "PacienteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Consultas", "PacienteId");
            AddForeignKey("dbo.Consultas", "PacienteId", "dbo.Pacientes", "PacienteId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "PacienteId", "dbo.Pacientes");
            DropIndex("dbo.Consultas", new[] { "PacienteId" });
            AlterColumn("dbo.Consultas", "PacienteId", c => c.Int());
            RenameColumn(table: "dbo.Consultas", name: "PacienteId", newName: "Paciente_PacienteId");
            CreateIndex("dbo.Consultas", "Paciente_PacienteId");
            AddForeignKey("dbo.Consultas", "Paciente_PacienteId", "dbo.Pacientes", "PacienteId");
        }
    }
}
