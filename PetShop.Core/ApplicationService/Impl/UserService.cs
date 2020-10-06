using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Impl
{
    public class UserService : IUserService
    {
        IUserRepository repository;

        public UserService(IUserRepository r)
        {
            repository = r;
        }

        public User ValidateUser(LoginInput loginInput)
        {
            return repository.ValidateUser(loginInput);
        }
    }
}
