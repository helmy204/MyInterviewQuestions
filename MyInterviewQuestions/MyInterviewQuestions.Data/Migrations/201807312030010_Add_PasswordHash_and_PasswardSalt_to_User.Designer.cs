// <auto-generated />
namespace MyInterviewQuestions.Data.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class Add_PasswordHash_and_PasswardSalt_to_User : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Add_PasswordHash_and_PasswardSalt_to_User));
        
        string IMigrationMetadata.Id
        {
            get { return "201807312030010_Add_PasswordHash_and_PasswardSalt_to_User"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
