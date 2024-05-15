using PetPals.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    internal class Pet
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }


        public Pet(string name, int age, string breed)
        {
            Name = name;
            if (age <= 0)
            {
                throw new InvalidPetAgeException("Age should be positive. It is invalid.");
            }
            Age = age;
            Breed = breed;
        }

        public override string ToString()
        {
            return $"Pet(Name: {Name}, Age: {Age}, Breed: {Breed})";
        }
    }
}
