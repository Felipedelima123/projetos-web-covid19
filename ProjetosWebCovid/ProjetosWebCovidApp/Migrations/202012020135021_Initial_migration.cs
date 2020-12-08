namespace ProjetosWebCovidApp.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Neighborhood",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Geometry = c.String(),
                })
                .PrimaryKey(t => t.ID);

        }

        public override void Down()
        {
            DropTable("dbo.Neighborhood");
        }
    }
}
