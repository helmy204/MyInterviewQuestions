namespace MyInterviewQuestions.Data.Migrations
{
    using MyInterviewQuestions.Core;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MyInterviewQuestions.Data.MyInterviewQuestionsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MyInterviewQuestions.Data.MyInterviewQuestionsContext";
        }

        protected override void Seed(MyInterviewQuestions.Data.MyInterviewQuestionsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Users.AddOrUpdate(
                u => u.Id,
                    new User() { Id = 1, UserName = "Root", Password = "P@ssw0rd", InsertedOn = DateTime.Now }
                );
        }
    }
}
