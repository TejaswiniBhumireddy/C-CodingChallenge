using System.Runtime.Serialization;

namespace PetPals.Exceptions
{
    internal class InsufficientFundsException : Exception
    {
        public InsufficientFundsException()
        {
        }

        public InsufficientFundsException(string? message) : base(message)
        {
        }

    }
}
