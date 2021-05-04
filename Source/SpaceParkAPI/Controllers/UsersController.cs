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

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dbContext.Users;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] User user)
        {
            bool validName = false;
            validName = await Swapi.ValidateName(user.PersonName);

            if (validName == false)
            {
                return NotFound("You entered an invalid name");
            }
            
            user.IsAdmin = false; 
           await _dbContext.Users.AddAsync(user);
           await  _dbContext.SaveChangesAsync();
           return StatusCode(StatusCodes.Status201Created, "You have created a user");
        }

    }

}
