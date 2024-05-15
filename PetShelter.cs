using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetPals.Model
{
    internal class PetShelter
    {
        private List<Pet> availablePets = new List<Pet>();

        public void AddPet(Pet pet)
        {
            availablePets.Add(pet);
        }

        public void RemovePet(Pet pet)
        {
            availablePets.Remove(pet);
        }
        public void ListAvailablePets()
        {
            foreach (var pet in availablePets)
            {
                try
                {
                    Console.WriteLine($"Name: {pet.Name}, Age: {pet.Age}, Breed: {pet.Breed}");
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("One or more properties of the pet are missing.");
                }
            }
        }
    }
}
