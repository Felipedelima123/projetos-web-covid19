namespace ProjetosWebCovidApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInfectedDatas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InfectedData",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Idade = c.Int(nullable: false),
                        Sexo = c.String(),
                        TpPaciente = c.String(),
                        Bairro = c.String(),
                        DataInclusao = c.DateTime(nullable: false),
                        DataNotificacao = c.DateTime(nullable: false),
                        DataRecuperacao = c.DateTime(nullable: false),
                        DataObito = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InfectedData");
        }
    }
}
