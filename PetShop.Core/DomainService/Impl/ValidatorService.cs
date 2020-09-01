using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PetShop.Core.DomainService.Impl
{
    public class ValidatorService : IValidatorService
    {
        public bool PetValidation(Pet pet)
        {
            throw new NotImplementedException();
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
