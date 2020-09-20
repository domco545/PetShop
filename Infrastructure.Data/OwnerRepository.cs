using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data
{
    public class OwnerRepository : IOwnerRepository
    {
        private int Id = 0;
        private List<Owner> owners = new List<Owner>();

        public Owner AddNewOwner(Owner owner)
        {
            owner.Id = Id++;
            owners.Add(owner);
            return owner;
        }

        public Owner DeleteOwner(int id)
        {
            var owner = owners.Find(owner => owner.Id == id);

            if (owner == null)
            {
                throw new KeyNotFoundException($"owner with id {id} doesnt exist");
            }

            owners.Remove(owner);

            return owner;
        }

        public List<Owner> GetAllOwners()
        {
            return owners;
        }

        public Owner GetOwner(int id)
        {
            var owner = owners.Find(owner => owner.Id == id);

            if (owner == null)
            {
                throw new KeyNotFoundException($"owner with id {id} doesnt exist");
            }

            return owner;
        }

        public bool UpdateOwner(Owner owner)
        {
            var ListIndex = owners.FindIndex(x => x.Id == owner.Id);

            if (ListIndex == -1)
            {
                throw new KeyNotFoundException($"owner with id {owner.Id} doesnt exist");
            }

            owners[ListIndex] = owner;
            return true;
        }
    }
}
