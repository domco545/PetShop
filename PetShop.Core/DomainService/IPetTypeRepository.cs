﻿using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IPetTypeRepository
    {
        public bool AddNewPetType(PetType type);
        public List<PetType> GetAllPetTypes();
        public PetType GetPetType(int id);
        public PetType DeletePetType(int id);
        public bool UpdatePetType(PetType type);
    }
}
