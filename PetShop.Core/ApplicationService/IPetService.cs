using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        public List<Pet> GetAllPets();
        public List<Pet> GetPetsByType(string querry);
        public Pet GetPetById(int id);
        public bool AddNewPet(Pet pet);
        public bool DeletePet(int Id);
        public bool UpdatePet(Pet pet);
        public List<Pet> SortPetsByPrice();
        public List<Pet> CheapestPets(int listSize);
        public bool PetIdExists(int id);
    }
}
