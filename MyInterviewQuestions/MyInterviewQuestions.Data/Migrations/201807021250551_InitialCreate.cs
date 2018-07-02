namespace MyInterviewQuestions.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        BodyText = c.String(),
                        UserId = c.Int(nullable: false),
                        InsertedOn = c.DateTime(nullable: false),
                        InsertedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        InsertedOn = c.DateTime(nullable: false),
                        InsertedBy = c.Int(),
                        UpdatedOn = c.DateTime(),
                        UpdatedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "UserId", "dbo.Users");
            DropIndex("dbo.Questions", new[] { "UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Questions");
        }
    }
}
