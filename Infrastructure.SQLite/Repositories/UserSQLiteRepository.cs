using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.SQLite.Repositories
{
    public class UserSQLiteRepository : IUserRepository
    {
        private readonly PetShopDBContext _ctx;

        public UserSQLiteRepository(PetShopDBContext context)
        {
            _ctx = context;
        }

        public User ValidateUser(LoginInput loginInput)
        {
            var res = _ctx.Users
                .FirstOrDefault(o => o.UserName == loginInput.UserName && o.Password == loginInput.Password);
            return res;
        }
    }
}
