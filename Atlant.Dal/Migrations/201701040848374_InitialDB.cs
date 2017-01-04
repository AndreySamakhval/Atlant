namespace Atlant.Dal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemCode = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Amount = c.Int(),
                        SpecialConsideration = c.Boolean(),
                        DateAdded = c.DateTime(nullable: false),
                        Storekeeper_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Storekeepers", t => t.Storekeeper_Id, cascadeDelete: true)
                .Index(t => t.Storekeeper_Id);
            
            CreateTable(
                "dbo.Storekeepers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Detail", "Storekeeper_Id", "dbo.Storekeepers");
            DropIndex("dbo.Detail", new[] { "Storekeeper_Id" });
            DropTable("dbo.Storekeepers");
            DropTable("dbo.Detail");
        }
    }
}
