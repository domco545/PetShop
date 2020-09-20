using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        public Owner AddNewOwner(Owner owner);
        public List<Owner> GetAllOwners();
        public Owner GetOwner(int id);
        public bool UpdateOwner(Owner owner);
        public Owner DeleteOwner(int id);
    }
}
