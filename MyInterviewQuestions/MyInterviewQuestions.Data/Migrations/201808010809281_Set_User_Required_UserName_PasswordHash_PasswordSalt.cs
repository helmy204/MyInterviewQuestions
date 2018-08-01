namespace MyInterviewQuestions.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Set_User_Required_UserName_PasswordHash_PasswordSalt : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PasswordHash", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "PasswordSalt", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "PasswordSalt", c => c.String());
            AlterColumn("dbo.Users", "PasswordHash", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
