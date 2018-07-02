using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Core
{
    /// <summary>
    /// Represents errors that occurs during retrieving single business entity from Repository.
    /// </summary>
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        //public ErrorCodes ErrorCode { get; private set; }

        /// <summary>
        /// Gets Business Entity name that doesn't found.
        /// </summary>
        public string EntityName { get; private set; }

        /// <summary>
        /// Gets the Business Entity Id that is requested from repository and doesn't found.
        /// </summary>
        public object EntityID { get; private set; }

        public string Title
        {
            get { return "Business Entity Not Found"; }
        }

        public string Description
        {
            get { return "Trying to access business entity that either don't have access to, or not exists."; }
        }

        public EntityNotFoundException() { }

        public EntityNotFoundException(object entityID, string message)
            : base(message)
        {
            this.EntityID = entityID;
        }

        //public EntityNotFoundException(object entityID, string message, ErrorCodes errorCode)
        //    : this(entityID, message)
        //{
        //    this.ErrorCode = errorCode;
        //}

        public EntityNotFoundException(string message, Exception inner) : base(message, inner) { }

        //public EntityNotFoundException(string message, Exception inner, ErrorCodes errorCode)
        //    : base(message, inner)
        //{
        //    this.ErrorCode = errorCode;
        //}

        protected EntityNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }

        //protected EntityNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context, ErrorCodes errorCode)
        //    : base(info, context)
        //{
        //    this.ErrorCode = errorCode;
        //}

        public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            base.GetObjectData(info, context);
        }
    }
}
