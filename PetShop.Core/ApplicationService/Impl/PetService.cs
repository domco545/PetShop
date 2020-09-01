using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Impl;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetShop.Core.ApplicationService.Impl
{
    public class PetService: IPetService
    {
        private IPetRepository _petRepository;
        private IValidatorService _validator;
        public PetService(IPetRepository petRepository, IValidatorService validator) 
        {
            _petRepository = petRepository;
            _validator = validator;
        }

        public bool AddNewPet(Pet pet)
        {
            return _petRepository.AddNewPet(pet);
        }

        public List<Pet> CheapestPets(int listSize)
        {
            if (listSize > 0)
            {
                return _petRepository.CheapestPets(listSize);
            }
            else 
            {
                throw new InvalidDataException("Cannot return list of size less than 1");
            }
        }

        public bool DeletePet(int Id)
        {
            if (Id > -1) 
            {
                return _petRepository.DeletePet(Id);
            }
            else
            {
                throw new InvalidDataException("Id must be greater or equal to zero");
            }
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAllPets();
        }

        public List<Pet> GetPetsByType(string querry)
        {
            if (_validator.StringLenght(querry, 1, 100)) 
            {
                return _petRepository.GetPetsByType(querry);
            }
            else
            {
                throw new InvalidDataException("querry string is too short or too long");
            }
        }

        public bool PetIdExists(int id)
        {
            return _petRepository.PetIdExists(id);
        }

        public List<Pet> SortPetsByPrice()
        {
            return _petRepository.SortPetsByPrice();
        }

        public bool UpdatePet(Pet pet)
        {
            if (pet.Id > -1)
            {
                _petRepository.UpdatePet(pet);
            }
            else
            {
                throw new InvalidDataException("Id must be equal or greater than zero");
            }
            return false;
        }
    }
}
