using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IValidatorService
    {
        public bool StringLenght(string data, int minLenght, int maxLenght);
        public bool ValidEmail(string email);
        public bool PetValidation(Pet pet);
        public bool OwnerValidation(Owner owner);
        public bool PetTypeValidator(PetType petType);
    }
}
