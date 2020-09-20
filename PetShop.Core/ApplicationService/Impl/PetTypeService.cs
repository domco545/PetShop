using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetTypeService : IPetTypeService
    {
        private IPetTypeRepository _petTypeRepository;
        private IValidatorService _validator;
        public PetTypeService(IPetTypeRepository petTypeRepository, IValidatorService validator)
        {
            _petTypeRepository = petTypeRepository;
            _validator = validator;
        }

        public bool AddNewPetType(PetType type)
        {
            _validator.PetTypeValidator(type);
            return _petTypeRepository.AddNewPetType(type);
        }

        public PetType DeletePetType(int id)
        {
            return _petTypeRepository.DeletePetType(id);
        }

        public List<PetType> GetAllPetTypes()
        {
            return _petTypeRepository.GetAllPetTypes();
        }

        public PetType GetPetType(int id)
        {
            return _petTypeRepository.GetPetType(id);
        }

        public bool UpdatePetType(PetType type)
        {
            _validator.PetTypeValidator(type);
            return _petTypeRepository.UpdatePetType(type);
        }
    }
}
