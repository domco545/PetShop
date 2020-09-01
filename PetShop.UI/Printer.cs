using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using System;

namespace PetShop.UI
{
    class Printer: IPrinter
    {
        private IPetService _petService;
        private IValidatorService _validatorService;

        public Printer(IPetService petService, IValidatorService validator) 
        {
            _petService = petService;
            _validatorService = validator;
        }
        public void Start() 
        {
            var read = "";

            while (read != "0")
            {
                Console.WriteLine("choose one of the options");
                Console.WriteLine("1 list all pets");
                Console.WriteLine("2 add new pet");
                Console.WriteLine("3 remove pet");
                Console.WriteLine("4 update pet");
                Console.WriteLine("5 get pets by type");
                Console.WriteLine("6 sort pets by price");
                Console.WriteLine("7 show 5 cheapest pets");
                Console.WriteLine("0 exit");
                Console.WriteLine("-------------------------------------------------");

                read = Console.ReadLine();

                switch (read)
                {
                    default:
                        Console.WriteLine("option not found try again \n"); ;
                        break;
                    case "1":
                        ListAllPets();
                        break;
                    case "2":
                        AddNewPet();
                        break;
                    case "3":
                        RemovePet();
                        break;
                    case "4":
                        UpdatePet();
                        break;
                    case "5":
                        GetPetsByType();
                        break;
                    case "6":
                        SortPetsByPrice();
                        break;
                    case "7":
                        ShowCheapestPets();
                        break;
                    case "0": return;
                }
            }
        }

        private void ListAllPets() 
        {
            var pets = _petService.GetAllPets();

            if (pets.Count < 1)
            {
                Console.WriteLine("the are no pets");
            }
            else
            {
                foreach (var pet in pets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
            Console.WriteLine();
        }

        private void AddNewPet() 
        {
            var NewPet = PetCreation();
            _petService.AddNewPet(NewPet);
            Console.Clear();
            Console.WriteLine("pet was added sucsessfully");
        }

        private Pet PetCreation() 
        {
            var NameReady = false;
            var TypeReady = false;
            var BirthdateReady = false;
            var SoldDateReady = false;
            var ColorReady = false;
            var OwnerFNameReady = false;
            var OwnerLNameReady = false;
            var OwnerAddressReady = false;
            var OwnerPhoneNumberReady = false;
            var OwnerEmailReady = false;
            var PriceReady = false;

            var NewPet = new Pet();
            var NewOwner = new Owner();

            #region Pet name
            Console.Clear();
            Console.WriteLine("1. enter pet name");
            while (!NameReady)
            {
                var PetName = Console.ReadLine();

                if (!_validatorService.StringLenght(PetName, 2, 20))
                {
                    Console.WriteLine("pet name is too long or too short");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    NameReady = true;
                    NewPet.Name = PetName;
                }
            }
            #endregion

            #region Pet type
            Console.Clear();
            Console.WriteLine("2. enter pet type");
            Console.WriteLine("printing types");
            var petTypes = Enum.GetValues(typeof(Pet.TypeOfPet));
            foreach (var petType in petTypes)
            {
                Console.WriteLine(petType);
            }
            while (!TypeReady)
            {
                var type = Console.ReadLine();
                if (Enum.TryParse(type, out Pet.TypeOfPet selected))
                {
                    NewPet.Type = selected;
                    TypeReady = true;
                }
                else
                {
                    Console.WriteLine("didnt match any type");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            #region Pet birthdate
            Console.Clear();
            Console.WriteLine("3. enter pet birthdate");
            Console.WriteLine("use format yyyy-mm-dd or dd/mm/yyyy");
            while (!BirthdateReady)
            {
                var read = Console.ReadLine();
                if (DateTime.TryParse(read, out DateTime res))
                {
                    NewPet.Birthdate = res;
                    BirthdateReady = true;
                }
                else
                {
                    Console.WriteLine("wrong format");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            #region Pet sold date
            Console.Clear();
            Console.WriteLine("4. enter pet sold date");
            Console.WriteLine("if you want to set sold time to now enter 1, if you want to set manual date enter 2");
            if (Console.ReadLine() == "1")
            {
                NewPet.SoldDate = DateTime.Now;
            }
            else if (Console.ReadLine() == "2")
            {
                Console.WriteLine("enter pet sold date");
                Console.WriteLine("use format yyyy-mm-dd or dd/mm/yyyy");
                while (!SoldDateReady)
                {
                    if (DateTime.TryParse(Console.ReadLine(), out DateTime res))
                    {
                        NewPet.SoldDate = res;
                        SoldDateReady = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong format try again\n");
                    }
                }
            }
            #endregion

            #region pet color
            Console.Clear();
            Console.WriteLine("5. enter pet color");
            while (!ColorReady)
            {
                var read = Console.ReadLine();
                if (_validatorService.StringLenght(read, 1, 40))
                {
                    NewPet.Color = read;
                    ColorReady = true;
                }
                else
                {
                    Console.WriteLine("color needs to be at least 1 letter long and maximum 40 letters long");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            #region owner first name
            Console.Clear();
            Console.WriteLine("6. enter Owner first name");
            while (!OwnerFNameReady)
            {
                var read = Console.ReadLine();
                if (_validatorService.StringLenght(read, 1, 20))
                {
                    NewOwner.FirstName = read;
                    OwnerFNameReady = true;
                }
                else
                {
                    Console.WriteLine("owner first name is too short or too long");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            #region owner last name
            Console.Clear();
            Console.WriteLine("7. enter Owner last name");
            while (!OwnerLNameReady)
            {
                var read = Console.ReadLine();
                if (_validatorService.StringLenght(read, 1, 20))
                {
                    NewOwner.LastName = read;
                    OwnerLNameReady = true;
                }
                else
                {
                    Console.WriteLine("owner last name is too short or too long");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            #region owner address
            Console.Clear();
            Console.WriteLine("8. enter Owner address");
            while (!OwnerAddressReady)
            {
                var read = Console.ReadLine();
                if (_validatorService.StringLenght(read, 4, 40))
                {
                    NewOwner.Address = read;
                    OwnerAddressReady = true;
                }
                else
                {
                    Console.WriteLine("owner address is too short or too long");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            #region owner phone number
            Console.Clear();
            Console.WriteLine("9. enter Owner phone number");
            while (!OwnerPhoneNumberReady)
            {
                var read = Console.ReadLine();
                if (_validatorService.StringLenght(read, 4, 20))
                {
                    NewOwner.PhoneNumber = read;
                    OwnerPhoneNumberReady = true;
                }
                else
                {
                    Console.WriteLine("owner phone number is too short or too long");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            #region owner email
            Console.Clear();
            Console.WriteLine("10. enter Owner email");
            while (!OwnerEmailReady)
            {
                var read = Console.ReadLine();
                if (_validatorService.ValidEmail(read))
                {
                    NewOwner.Email = read;
                    OwnerEmailReady = true;
                }
                else
                {
                    Console.WriteLine("invalid email");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            #region pet price
            Console.Clear();
            Console.WriteLine("11. enter pet price");
            while (!PriceReady)
            {
                if (double.TryParse(Console.ReadLine(), out double res))
                {
                    NewPet.price = res;
                    PriceReady = true;
                }
                else
                {
                    Console.WriteLine("wrong format");
                    Console.WriteLine("try again\n");
                }
            }
            #endregion

            NewPet.Owner = NewOwner;
            return NewPet;
        }

        private void RemovePet() 
        {
            Console.WriteLine("write id of pet you want to delete");
            var ready = false;

            while (!ready)
            {
                if (!int.TryParse(Console.ReadLine(), out int num))
                {
                    Console.WriteLine("pet Id must be a number");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    if (_petService.DeletePet(num))
                    {
                        Console.WriteLine($"pet with Id:{num} was deleted\n");
                        ready = true;
                    }
                    else
                    {
                        Console.WriteLine($"pet with Id:{num} wasnt found");
                        Console.WriteLine("try again\n");
                    }
                }
            }

        }

        private void UpdatePet() 
        {
            var IdReady = false;
            Console.WriteLine("enter Id of pet you want to edit");

            while (!IdReady) 
            {
                var read = Console.ReadLine();
                if (int.TryParse(read, out int res))
                {
                    if (_petService.PetIdExists(res))
                    {
                        var updatedPet = PetCreation();
                        updatedPet.Id = res;
                        _petService.UpdatePet(updatedPet);
                        Console.WriteLine("Pet was updated");
                        IdReady = true;
                    }
                    else
                    {
                        Console.WriteLine("Id not found");
                        Console.WriteLine("try again\n");
                    }
                }
                else
                {
                    Console.WriteLine("Id must be a number");
                    Console.WriteLine("try again\n");
                }
            }
        }

        private void GetPetsByType() 
        {
            var ready = false;
            Console.WriteLine("All types");
            foreach (var petType in Enum.GetValues(typeof(Pet.TypeOfPet)))
            {
                Console.WriteLine(petType);
            }

            Console.WriteLine("Write type you want to search");

            while (!ready)
            {
                var read = Console.ReadLine();
                if (read == null)
                {
                    Console.WriteLine("search cannot be null");
                    Console.WriteLine("try again\n");
                }
                else
                if (!_validatorService.StringLenght(read, 1, 100))
                {
                    Console.WriteLine("search is too short or too long");
                    Console.WriteLine("try again\n");
                }
                else
                {
                    var found = _petService.GetPetsByType(read);
                    if (found.Count < 1)
                    {
                        Console.WriteLine($"no results matching {read} \n");
                        ready = true;
                    }
                    else
                    {
                        foreach (var pet in found)
                        {
                            Console.WriteLine(pet.ToString());
                        }
                        Console.WriteLine();
                        ready = true;
                    }
                }
            }
        }

        private void SortPetsByPrice() 
        {
            var pets = _petService.SortPetsByPrice();

            if (pets.Count < 1)
            {
                Console.WriteLine("the are no pets");
            }
            else
            {
                foreach (var pet in pets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
            Console.WriteLine();
        }

        private void ShowCheapestPets() 
        {
            var petCount = 5;
            var pets = _petService.CheapestPets(petCount);

            if (pets.Count < 1)
            {
                Console.WriteLine("the are no pets");
            }
            else
            {
                foreach (var pet in pets)
                {
                    Console.WriteLine(pet.ToString());
                }
            }
            Console.WriteLine();
        }
    }
}
