using Microsoft.EntityFrameworkCore;
using PetShop.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.SQLite
{
    public class PetShopDBContext : DbContext
    {
        public PetShopDBContext(DbContextOptions<PetShopDBContext> opt) : base(opt){ }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
