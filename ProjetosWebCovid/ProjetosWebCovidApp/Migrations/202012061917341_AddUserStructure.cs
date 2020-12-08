namespace ProjetosWebCovidApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserStructure : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPosition",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPosition", "UserId", "dbo.User");
            DropIndex("dbo.UserPosition", new[] { "UserId" });
            DropTable("dbo.User");
            DropTable("dbo.UserPosition");
        }
    }
}
