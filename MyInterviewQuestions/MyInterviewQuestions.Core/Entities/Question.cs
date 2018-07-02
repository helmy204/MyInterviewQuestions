using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Core
{
    public class Question : AuditableEntity
    {
        /// <summary>
        /// Gets or sets a question title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or set a question body text
        /// </summary>
        public string BodyText { get; set; }

        /// <summary>
        /// Gets or sets question user id
        /// </summary>
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
