using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Gets or sets the salted/hashed form of the user password
        /// </summary>
        [Required]
        public string PasswordHash { get; set; }

        /// <summary>
        /// Gets or sets the password salt
        /// </summary>
        [Required]
        public string PasswordSalt { get; set; }

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
