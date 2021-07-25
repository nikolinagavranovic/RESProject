namespace WebClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Relations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstResourceId = c.Int(nullable: false),
                        SecondResourceId = c.Int(nullable: false),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RelationTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.RelationTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ResourceTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.ResourceTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resources", "Type_Id", "dbo.ResourceTypes");
            DropForeignKey("dbo.Relations", "Type_Id", "dbo.RelationTypes");
            DropIndex("dbo.Resources", new[] { "Type_Id" });
            DropIndex("dbo.Relations", new[] { "Type_Id" });
            DropTable("dbo.ResourceTypes");
            DropTable("dbo.Resources");
            DropTable("dbo.RelationTypes");
            DropTable("dbo.Relations");
        }
    }
}
