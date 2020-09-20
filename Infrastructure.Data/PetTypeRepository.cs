using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class PetTypeRepository : IPetTypeRepository
    {
        private int Id = 0;
        private List<PetType> petTypes = new List<PetType>();

        public bool AddNewPetType(PetType type)
        {
            type.Id = Id++;
            petTypes.Add(type);
            return true;
        }

        public PetType DeletePetType(int id)
        {
            var petType = petTypes.Find(type => type.Id == id);

            if (petType == null)
            {
                throw new KeyNotFoundException($"pet type with id {id} doesnt exist");
            }

            petTypes.Remove(petType);

            return petType;
        }

        public List<PetType> GetAllPetTypes()
        {
            return petTypes;
        }

        public PetType GetPetType(int id)
        {
            var petType = petTypes.Find(type => type.Id == id);

            if (petType == null)
            {
                throw new KeyNotFoundException($"pet type with id {id} doesnt exist");
            }

            return petType;
        }

        public bool UpdatePetType(PetType type)
        {
            var ListIndex = petTypes.FindIndex(x => x.Id == type.Id);

            if (ListIndex == -1)
            {
                throw new KeyNotFoundException($"pet type with id {type.Id} doesnt exist");
            }

            petTypes[ListIndex] = type;
            return true;
        }
    }
}
