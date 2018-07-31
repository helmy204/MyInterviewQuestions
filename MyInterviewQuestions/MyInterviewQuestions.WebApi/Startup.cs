using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyInterviewQuestions.WebApi.Startup))]
namespace MyInterviewQuestions.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}