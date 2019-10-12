using System;
namespace Company.Project.Domain.Exceptions
{
    public class InvalidAddressString : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:InvalidAddressStringException"/> class
        /// </summary>
        public InvalidAddressString()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InvalidAddressStringException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        public InvalidAddressString(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:InvalidAddressStringException"/> class
        /// </summary>
        /// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
        /// <param name="inner">The exception that is the cause of the current exception. </param>
        public InvalidAddressString(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}
