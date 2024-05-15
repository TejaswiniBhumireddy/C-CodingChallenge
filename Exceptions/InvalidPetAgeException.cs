using System.Runtime.Serialization;

namespace PetPals.Exceptions
{
    internal class InvalidPetAgeException : Exception
    {
        public InvalidPetAgeException()
        {
        }

        public InvalidPetAgeException(string? message) : base(message)
        {
        }

    }
}