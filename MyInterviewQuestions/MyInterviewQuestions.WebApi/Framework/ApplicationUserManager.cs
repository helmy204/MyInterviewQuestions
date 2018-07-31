using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyInterviewQuestions.Core;
using MyInterviewQuestions.Data;

namespace MyInterviewQuestions.WebApi.Framework
{
    public class ApplicationUserManager : UserManager<User, int>
    {
        public ApplicationUserManager(IdentityRepository store) : base(store)
        {
        }

        public override async Task<IdentityResult> CreateAsync(User user)
        {
            user.InsertedOn = DateTime.Now;

            return await base.CreateAsync(user);
        }

    }
}