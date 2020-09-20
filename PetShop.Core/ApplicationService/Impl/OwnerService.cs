using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PetShop.Core.ApplicationService.Impl
{
    public class OwnerService : IOwnerService
    {
        private IOwnerRepository _ownerRepository;
        private IValidatorService _validator;
        public OwnerService(IOwnerRepository ownerRepository, IValidatorService validator)
        {
            _ownerRepository = ownerRepository;
            _validator = validator;
        }

        public Owner AddNewOwner(Owner owner)
        {
            _validator.OwnerValidation(owner);
            return _ownerRepository.AddNewOwner(owner);
        }

        public Owner DeleteOwner(int id)
        {
            return _ownerRepository.DeleteOwner(id);
        }

        public List<Owner> GetAllOwners()
        {
            return _ownerRepository.GetAllOwners();
        }

        public Owner GetOwner(int id)
        {
            return _ownerRepository.GetOwner(id);
        }

        public bool UpdateOwner(Owner owner)
        {
            _validator.OwnerValidation(owner);
            return _ownerRepository.UpdateOwner(owner);
        }
    }
}
