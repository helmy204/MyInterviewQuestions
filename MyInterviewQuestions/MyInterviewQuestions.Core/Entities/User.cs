using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Core
{
    public class User : AuditableEntity, IUser<int>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public User()
        {
            this.Questions = new HashSet<Question>();
        }

        /// <summary>
        /// Gets or sets the username
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User,int> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
