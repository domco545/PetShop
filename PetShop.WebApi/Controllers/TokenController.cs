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
    public class TokenController : ControllerBase
    {
        private IUserService service;
        private IAuthentication authentication;

        public TokenController(IUserService ser, IAuthentication authHelper)
        {
            service = ser;
            authentication = authHelper;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInput loginInput)
        {
            var user = service.ValidateUser(loginInput);

            // Authentication unsuccessful
            if (user == null )
            {
                return Unauthorized();
            }

            // Authentication successful
            return Ok(new
            {
                username = loginInput.UserName,
                token = authentication.GenerateToken(user)
            });
        }
    }
}
