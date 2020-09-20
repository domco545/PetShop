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
    public class OwnersController : ControllerBase
    {
        IOwnerService _ownerService;
        public OwnersController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }
        // GET: api/<OwnersController>
        [HttpGet]
        public ActionResult<IEnumerable<Owner>> Get()
        {
            try
            {
                var owners = _ownerService.GetAllOwners();
                if (owners.Count < 1)
                {
                    return StatusCode(404, "no owners to show");
                }

                return owners;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }

        }

        // GET api/<OwnersController>/5
        [HttpGet("{id}")]
        public ActionResult<Owner> Get(int id)
        {
            try
            {
                return _ownerService.GetOwner(id);
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

        // POST api/<OwnersController>
        [HttpPost]
        public ActionResult<Owner> Post([FromBody] Owner owner)
        {
            try
            {
                return _ownerService.AddNewOwner(owner);
            }
            catch (Exception e) 
            {
                return StatusCode(500, e.Message);
            }
        }

        // PUT api/<OwnersController>/5
        [HttpPut]
        public ActionResult<Owner> Put([FromBody] Owner owner)
        {
            try
            {
                _ownerService.UpdateOwner(owner);
                return owner;
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

        // DELETE api/<OwnersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var owner = _ownerService.DeleteOwner(id);
                return StatusCode(202, owner);
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
