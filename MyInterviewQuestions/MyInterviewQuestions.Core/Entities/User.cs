using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Core
{
   public class User:AuditableEntity
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
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password
        /// </summary>
        public string Password { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
    }
}
