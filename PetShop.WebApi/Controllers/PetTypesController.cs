using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
    public class PetTypesController : ControllerBase
    {
        IPetTypeService _petTypeService;

        public PetTypesController(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }
        // GET: api/<PetTypesController>
        [HttpGet]
        public ActionResult<IEnumerable<PetType>> Get()
        {
            try
            {
                var petTypes = _petTypeService.GetAllPetTypes();
                if (petTypes.Count < 1)
                {
                    return StatusCode(404, "no pet types to show");
                }

                return petTypes;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET api/<PetTypesController>/5
        [HttpGet("{id}")]
        public ActionResult<PetType> Get(int id)
        {
            try
            {
                return _petTypeService.GetPetType(id);
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

        // POST api/<PetTypesController>
        [HttpPost]
        public ActionResult<PetType> Post([FromBody] PetType petType)
        {
            try
            {
                _petTypeService.AddNewPetType(petType);
                return petType;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<PetTypesController>/5
        [HttpPut]
        public ActionResult<PetType> Put([FromBody] PetType petType)
        {
            try
            {
                _petTypeService.UpdatePetType(petType);
                return petType;
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

        // DELETE api/<PetTypesController>/5
        [HttpDelete("{id}")]
        public ActionResult<PetType> Delete(int id)
        {
            try
            {
                var petType = _petTypeService.DeletePetType(id);
                return StatusCode(202, petType);
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
