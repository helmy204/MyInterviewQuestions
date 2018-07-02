using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Core
{
    public abstract class AuditableEntity : BaseEntity
    {
        /// <summary>
        /// Gets or sets the date and time of entity insertion
        /// </summary>
        public DateTime InsertedOn { get; set; }
        public Nullable<int> InsertedBy { get; set; }
        public Nullable<System.DateTime> UpdatedOn { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
}
