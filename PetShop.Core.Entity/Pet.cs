using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Core.Entity
{
    public class Pet
    {
        public enum TypeOfPet
        {
          Dog,
          Cat,
          Fish,
          Bird,
        }

        public int? Id { get; set; }
        public string Name { get; set; }
        //public TypeOfPet Type { get; set; }
        public PetType Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public Owner Owner { get; set; }
        public double price { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}, Name:{Name}, Type:{Type}, Owner:{Owner.FirstName} {Owner.LastName}, Price:{price}";
        }
    }
}
