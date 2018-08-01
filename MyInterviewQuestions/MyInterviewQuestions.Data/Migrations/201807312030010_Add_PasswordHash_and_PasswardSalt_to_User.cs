namespace MyInterviewQuestions.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_PasswordHash_and_PasswardSalt_to_User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "PasswordHash", c => c.String());
            AddColumn("dbo.Users", "PasswordSalt", c => c.String());
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            DropColumn("dbo.Users", "PasswordSalt");
            DropColumn("dbo.Users", "PasswordHash");
        }
    }
}
