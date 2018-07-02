using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInterviewQuestions.Core
{
    public static class Check
    {
        /// <summary>
        /// Ensures that a parameter value is not null,
        /// otherwise an exception is thrown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentName"></param>
        /// <param name="value"></param>
        /// <returns>Same value</returns>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        public static T ArgumentNotNull<T>(string argumentName, T value) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            return value;
        }

        /// <summary>
        /// Ensures that a parameter value is not null,
        /// otherwise an exception is thrown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentName"></param>
        /// <param name="value"></param>
        /// <returns>Same value</returns>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        public static T? ArgumentNotNull<T>(string argumentName, T? value) where T : struct
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            return value;
        }


        public static TProperty ArgumentPropertyNotNull<TProperty>(string argumentName, string propertyName, TProperty propertyValue) where TProperty : class
        {
            if (propertyValue == null)
            {
                throw new ArgumentNullException(argumentName, string.Format("{0}.{1} is null.", argumentName, propertyName));
            }
            return propertyValue;
        }

        public static TProperty? ArgumentPropertyNotNull<TProperty>(string argumentName, string propertyName, TProperty? propertyValue) where TProperty : struct
        {
            if (propertyValue == null)
            {
                throw new ArgumentNullException(argumentName, string.Format("{0}.{1} is null.", argumentName, propertyName));
            }
            return propertyValue;
        }

        public static TProperty? ArgumentPropertyNotNullOrDefault<TProperty>(string argumentName, string propertyName, TProperty? propertyValue) where TProperty : struct
        {

            if (propertyValue == null)
            {
                throw new ArgumentNullException(argumentName, string.Format("{0}.{1} is null.", argumentName, propertyName));
            }

            if (default(TProperty).Equals(propertyValue))
            {
                throw new ArgumentException($"{argumentName}.{propertyName}  cannot be {propertyValue}", argumentName);
            }

            return propertyValue;
        }

        public static string ArgumentNotNullOrEmpty(string argumentName, string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Argument value cannot be an empty string.", argumentName);
            }

            return value;
        }

        /// <summary>
        /// Ensures that a parameter value is not null or default value (eg. 0 for int),
        /// otherwise an exception is thrown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="argumentName"></param>
        /// <param name="value"></param>
        /// <returns>Same value</returns>
        /// <exception cref="ArgumentNullException">Thrown when the value is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the value is default.</exception>
        public static T? ArgumentNotNullOrDefault<T>(string argumentName, T? value) where T : struct
        {

            if (value == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            if (default(T).Equals(value))
            {
                throw new ArgumentException($"Argument value cannot be {value}", argumentName);
            }

            return value;
        }

        // Use IReadOnlyCollection<T> instead of IEnumerable<T> to discourage double enumeration
        public static void ArgumentNotNullOrEmpty<T>(string argumentName, IReadOnlyCollection<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(argumentName);
            }
            if (items.Count == 0)
            {
                throw new ArgumentException("Collection must contain at least one item.", argumentName);
            }
        }


        public static void ArgumentValid(bool valid, string argumentName, string exceptionMessage)
        {
            if (!valid)
            {
                throw new ArgumentException(exceptionMessage, argumentName);
            }
        }


        public static void EntityNotNull(object entityKey, object value, string exceptionMessage = null)
        {
            if (value == null)
            {
                throw new EntityNotFoundException(entityKey, exceptionMessage);
            }
        }

        ///// <summary>
        ///// Ensures that a certain business rule is valid,
        ///// otherwise an exception is thrown.
        ///// </summary>
        ///// <param name="businessRule"></param>
        ///// <param name="exceptionMessage"></param>
        ///// <exception cref="BusinessRuleException">Thrown when the business rule is false.</exception>
        //public static void BusinessRule(bool businessRule, string exceptionMessage)
        //{
        //    if (!businessRule)
        //    {
        //        throw new BusinessRuleException(exceptionMessage);
        //    }
        //}


        ///// <summary>
        ///// Ensures that a certain validation is true,
        ///// otherwise an exception is thrown.
        ///// </summary>
        ///// <param name="valid"></param>
        ///// <param name="validationResult"></param>
        ///// <param name="exceptionMessage"></param>
        ///// <exception cref="ValidationException">Thrown when the validation is false.</exception>
        //public static void Validation(bool valid, IEnumerable<ValidationResult> validationResult, string exceptionMessage)
        //{
        //    if (!valid)
        //    {
        //        throw new ValidationException(exceptionMessage, validationResult);
        //    }
        //}

        public static void ArgumentHasNoNulls<T>(string argumentName, IReadOnlyCollection<T> items) where T : class
        {
            if (items == null)
            {
                throw new ArgumentNullException(argumentName);
            }

            if (items.Any(e => e == null))
            {
                throw new ArgumentException(argumentName + " has null item.");
            }
        }

        private static bool IsNullableType(this Type type)
        {
            return !type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>));
        }
    }
}
