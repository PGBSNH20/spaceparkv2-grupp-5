using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;
using SpaceParkAPI.Services;
using SpaceParkAPI.ViewModels;

namespace SpaceParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersService _userService;

        public UsersController(UsersService userService)
        {
            _userService = userService;
        }

        // We have choosed to not include a GET method for the users security

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserVM user)
        {
            await _userService.AddUser(user);
            return Ok("A user has been created");

          

            // user.IsAdmin = false; 
            //await _dbContext.Users.AddAsync(user);
            //await  _dbContext.SaveChangesAsync();
            //return StatusCode(StatusCodes.Status201Created, "You have created a user");


        }

    }

}
