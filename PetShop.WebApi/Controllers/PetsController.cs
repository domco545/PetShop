using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
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
            try
            {
                return _petService.GetPetById(id);
            }
            catch (KeyNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // POST api/<PetsController>
        [HttpPost]
        public IActionResult Post([FromBody] Pet pet)
        {
            try
            {
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
                return StatusCode(202, $"Deleted pet with id {id}");
            }
            catch (KeyNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
