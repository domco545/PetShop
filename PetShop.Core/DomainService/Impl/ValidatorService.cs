using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace PetShop.Core.DomainService.Impl
{
    public class ValidatorService : IValidatorService
    {
        public bool PetValidation(Pet pet)
        {
            if (string.IsNullOrEmpty(pet.Name) || !StringLenght(pet.Name,4,100))
            {
                throw new InvalidDataException("Name cannot be empty or null and needs to be between 4 and 100 characters");
            }

            if (!Enum.IsDefined(typeof(Pet.TypeOfPet), pet.Type))
            {
                throw new InvalidDataException("Pet needs to have valid pet type");
            }

            if (pet.Birthdate == null)
            {
                throw new InvalidDataException("Birthdate cannot be null");
            }

            if (pet.SoldDate == null)
            {
                throw new InvalidDataException("Sold date cannot be null");
            }

            if (string.IsNullOrEmpty(pet.Color) || StringLenght(pet.Color, 2, 100))
            {
                throw new InvalidDataException("Pet color cannot be empty and needs to be between 2 and 100 characters");
            }

            /*
            if (pet.Owner == null || !OwnerValidation(pet.Owner))
            {
                throw new InvalidDataException("");
            }
            */

            if (double.IsNegative(pet.price))
            {
                throw new InvalidDataException("Price cannot be negative number");
            }

            return true;
        }

        public bool OwnerValidation(Owner owner) 
        {
            if (string.IsNullOrEmpty(owner.FirstName) || !StringLenght(owner.FirstName, 4, 100))
            {
                throw new InvalidDataException("First name cannot be empty and needs to be between 4 and 100 characters");
            }

            if (string.IsNullOrEmpty(owner.LastName) || !StringLenght(owner.LastName, 4, 100))
            {
                throw new InvalidDataException("Last name cannot be empty and needs to be between 4 and 100 characters");
            }

            if (string.IsNullOrEmpty(owner.Address) || !StringLenght(owner.Address, 2, 40))
            {
                throw new InvalidDataException("Address cannot be empty and needs to be between 2 and 40 characters");
            }

            if (string.IsNullOrEmpty(owner.PhoneNumber) || !StringLenght(owner.PhoneNumber, 4, 15))
            {
                throw new InvalidDataException("Phone number cannot be empty and needs to be beyween 4 and 15 characters");
            }

            if (!ValidEmail(owner.Email))
            {
                throw new InvalidDataException("Invalid email");
            }

            return true;
        }

        public bool StringLenght(string data, int minLenght, int maxLenght)
        {
            if (data == null) return false;
            if (data.Length < minLenght || data.Length > maxLenght) return false;

            return true;
        }

        public bool ValidEmail(string email)
        {
           return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }
    }
}
