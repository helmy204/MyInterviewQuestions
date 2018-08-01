using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyInterviewQuestions.Core;
using MyInterviewQuestions.Data;
using MyInterviewQuestions.Service;

namespace MyInterviewQuestions.WebApi.Framework
{
    public class ApplicationUserManager : UserManager<User, int>
    {
        private readonly IEncryptionService _encryptionService;

        public ApplicationUserManager(IdentityRepository store, IEncryptionService encryptionService) : base(store)
        {
            _encryptionService = encryptionService;
        }

        public override async Task<IdentityResult> CreateAsync(User user)
        {


            user.InsertedOn = DateTime.Now;

            return await base.CreateAsync(user);
        }

        public override async Task<User> FindAsync(string userName, string password)
        {
            return await base.FindAsync(userName, password);
        }

        protected override async Task<bool> VerifyPasswordAsync(IUserPasswordStore<User, int> store, User user, string password)
        {
            string userEnteredPasswordHash = _encryptionService.CreatePasswordHash(password, user.PasswordSalt);
            return userEnteredPasswordHash == user.PasswordHash;
            //return base.VerifyPasswordAsync(store, user, password);
        }

    }
}