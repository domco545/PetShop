﻿using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService
{
    public interface IUserService
    {
        public User ValidateUser(LoginInput loginInput);
    }
}
