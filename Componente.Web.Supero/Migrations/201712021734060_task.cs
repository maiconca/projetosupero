namespace Componente.Web.Supero.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class task : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Ativo = c.Boolean(nullable: false),
                        Descricao = c.String(),
                        DataCriacao = c.DateTime(),
                        DataEdicao = c.DateTime(),
                        DataRemocao = c.DateTime(),
                        DataConclusao = c.DateTime(),
                        CodigoTaskStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Codigo)
                .ForeignKey("dbo.TaskStatus", t => t.CodigoTaskStatus, cascadeDelete: true)
                .Index(t => t.CodigoTaskStatus);
            
            CreateTable(
                "dbo.TaskStatus",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Task", "CodigoTaskStatus", "dbo.TaskStatus");
            DropIndex("dbo.Task", new[] { "CodigoTaskStatus" });
            DropTable("dbo.TaskStatus");
            DropTable("dbo.Task");
        }
    }
}
