using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IPetTypeService
    {
        public bool AddNewPetType(PetType type);
        public List<PetType> GetAllPetTypes();
        public PetType GetPetType(int id);
        public PetType DeletePetType(int id);
        public bool UpdatePetType(PetType type);
    }
}
