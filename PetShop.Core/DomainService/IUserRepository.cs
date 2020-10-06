using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IUserRepository
    {
        public User ValidateUser(LoginInput loginInput);
    }
}
