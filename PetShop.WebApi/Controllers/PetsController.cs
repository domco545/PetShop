using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService _petService;
        private IValidatorService _validatorService;

        public PetsController(IPetService petService, IValidatorService validatorService)
        {
            _petService = petService;
            _validatorService = validatorService;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            var pets = _petService.GetAllPets();

            if (pets.Count < 1)
            {
                return StatusCode(404, "no pets to return");
            }
            else
            {
                return pets;
            }
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            var pet = _petService.GetPetById(id);
            if (pet == null)
            {
                return StatusCode(404, "no pet with matching id");
            }
            else
            {
                return pet;
            }
        }

        // POST api/<PetsController>
        [HttpPost]
        public IActionResult Post([FromBody] Pet pet)
        {
            try
            {
                _validatorService.PetValidation(pet);

                _petService.AddNewPet(pet);
                return StatusCode(201, pet);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_petService.DeletePet(id))
                {
                    return StatusCode(202, $"Deleted pet with id {id}");
                }
                else
                {
                    return StatusCode(404 , $"Pet with id {id} wasnt found");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
