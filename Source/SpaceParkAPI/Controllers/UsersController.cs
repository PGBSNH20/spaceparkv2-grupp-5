using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private SpaceDbContext _dbContext;

        public UsersController(SpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // We have choosed to not include a GET method for the users security

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            var usersExist = _dbContext.Users.Any(p => p.PersonName == user.PersonName);

            bool validName = false;
            validName = await Swapi.ValidateName(user.PersonName);

            if (validName == false)
            {
                return NotFound("You entered an invalid name");
            }

            if (usersExist)
            {
                return BadRequest("You can't create multiple users");
            }

            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.Username))
            {
                return BadRequest("Either your password or username was empty");
            }
            
            user.IsAdmin = false; 
           await _dbContext.Users.AddAsync(user);
           await  _dbContext.SaveChangesAsync();
           return StatusCode(StatusCodes.Status201Created, "You have created a user");
        }

    }

}
