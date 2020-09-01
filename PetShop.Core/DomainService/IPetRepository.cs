using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using static PetShop.Core.Entity.Pet;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        public List<Pet> GetAllPets();
        public List<Pet> GetPetsByType(string querry);
        public bool AddNewPet(Pet pet);
        public bool DeletePet(int Id);
        public bool UpdatePet(Pet pet);
        public List<Pet> SortPetsByPrice();
        public List<Pet> CheapestPets(int listSize);
        public bool PetIdExists(int id);
    }
}
