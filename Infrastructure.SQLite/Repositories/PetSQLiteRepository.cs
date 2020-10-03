using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.SQLite.Repositories
{
    public class PetSQLiteRepository : IPetRepository
    {
        private readonly PetShopDBContext _ctx;

        public PetSQLiteRepository(PetShopDBContext ctx)
        {
            _ctx = ctx;
        }

        public bool AddNewPet(Pet pet)
        {
            var entry = _ctx.Pets.Add(pet);
            _ctx.SaveChanges();
            return true;
        }

        public List<Pet> CheapestPets(int listSize)
        {
            throw new NotImplementedException();
        }

        public bool DeletePet(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Pet> GetAllPets()
        {
            return _ctx.Pets
                .Include(o => o.Owner)
                .Include(o => o.Type)
                .ToList();
        }

        public Pet GetPetById(int id)
        {
            return _ctx.Pets
                .Include(o => o.Owner)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Pet> GetPetsByType(string querry)
        {
            throw new NotImplementedException();
        }

        public bool PetIdExists(int id)
        {
            throw new NotImplementedException();
        }

        public List<Pet> SortPetsByPrice()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePet(Pet pet)
        {
            var entry = _ctx.Pets.Update(pet);
            _ctx.SaveChanges();
            return true;
        }
    }
}
