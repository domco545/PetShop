using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.ApplicationService;
using PetShop.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PetShop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetService _petService;

        public PetsController(IPetService petService)
        {
            _petService = petService;
        }

        // GET: api/<PetsController>
        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/<PetsController>/5
        [HttpGet("{id}")]
        public ActionResult<Pet> Get(int id)
        {
            return _petService.GetPetById(id);
        }

        // POST api/<PetsController>
        [HttpPost]
        public void Post([FromBody] Pet pet)
        {
            _petService.AddNewPet(pet);
        }

        // PUT api/<PetsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PetsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
