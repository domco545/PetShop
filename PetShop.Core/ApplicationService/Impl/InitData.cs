using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.ApplicationService.Impl
{
    public class InitData
    {
        private IPetRepository _petRepository;
        private IOwnerRepository _ownerRepository;
        private IPetTypeRepository _petTypeRepository;

        public InitData(IPetRepository petRepository, IOwnerRepository ownerRepository, IPetTypeRepository petTypeRepository) 
        {
            _petRepository = petRepository;
            _ownerRepository = ownerRepository;
            _petTypeRepository = petTypeRepository;
            AddPets();
            AddOwners();
            AddPetTypes();
        }

        private void AddPets() 
        {
            _petRepository.AddNewPet(new Pet() { Name = "Cute Doggo", Birthdate = DateTime.Now.AddYears(-2), Color = "Brown", Owner = new Owner() { FirstName = "Peter", LastName = "Nielsen", Address = "some address", Email = "peter@gmail.com", PhoneNumber = "51234567" }, price = 143.50, SoldDate = DateTime.Now, Type = new PetType() {  Name = "Dog" } });
            _petRepository.AddNewPet(new Pet() { Name = "Cute cat", Birthdate = DateTime.Now.AddYears(-1), Color = "Gray", Owner = new Owner() { FirstName = "Martin", LastName = "Rasmussen", Address = "some address", Email = "martin@gmail.com", PhoneNumber = "51233764" }, price = 120.00, SoldDate = DateTime.Now, Type = new PetType() { Name = "Cat" } });
        }

        private void AddOwners() 
        {
            _ownerRepository.AddNewOwner(new Owner() { Id = 0, FirstName = "Peter", LastName = "Nielsen", Address = "some address", Email = "peter@gmail.com", PhoneNumber = "51234567" });
            _ownerRepository.AddNewOwner(new Owner() { Id = 1, FirstName = "Martin", LastName = "Rasmussen", Address = "some address", Email = "martin@gmail.com", PhoneNumber = "51233764" });
        }

        private void AddPetTypes() 
        {
            _petTypeRepository.AddNewPetType(new PetType() { Id = 0, Name = "Dog" });
            _petTypeRepository.AddNewPetType(new PetType() {Id = 1, Name = "Cat" });
        }
    }
}
