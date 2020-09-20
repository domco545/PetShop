using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Infrastructure.Data
{
    public class PetRepository: IPetRepository
    {
        private int Id = 0;
        private List<Pet> AllPets = new List<Pet>();

        public bool AddNewPet(Pet pet)
        {
            pet.Id = Id++;
            AllPets.Add(pet);
            return true;
        }

        public List<Pet> CheapestPets(int listSize)
        {
            return AllPets.OrderBy(pet => pet.price).Take(listSize).ToList();
        }

        public bool DeletePet(int Id)
        {
            if (!AllPets.Any(pet => pet.Id == Id)) 
            {
                throw new KeyNotFoundException($"pet with id {Id} doesnt exist");
            }

            AllPets = AllPets.Where(pet => pet.Id != Id).ToList();
            return true;
        }

        public List<Pet> GetAllPets()
        {
            return AllPets;
        }

        public Pet GetPetById(int id)
        {
            var pet = AllPets.Find(pet => pet.Id == id);

            if (pet == null)
            {
                throw new KeyNotFoundException($"pet with id {pet.Id} doesnt exist");
            }

            return pet;
        }

        public List<Pet> GetPetsByType(string querry)
        {
            return AllPets.Where(Pet => Pet.Type.ToString().ToLower().Contains(querry.ToLower())).ToList();
        }

        public bool PetIdExists(int id)
        {
            return AllPets.Any(pet => pet.Id == id);
        }

        public List<Pet> SortPetsByPrice()
        {
            return AllPets.OrderBy(pet => pet.price).ToList();
        }

        public bool UpdatePet(Pet pet)
        {
            var ListIndex = AllPets.FindIndex(x => x.Id == pet.Id);

            if (ListIndex == -1)
            {
                throw new KeyNotFoundException($"pet with id {pet.Id} doesnt exist");
            }

            AllPets[ListIndex] = pet;
            return true;
        }
    }
}
