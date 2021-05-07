using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceParkAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class SpacePortsController : ControllerBase
    {
        private SpaceDbContext _dbContext;

        public SpacePortsController(SpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [ApiKeyAuth]
        [HttpGet]
        public IEnumerable<SpacePort> GetAllSpacePorts()
        {
            return _dbContext.SpacePorts;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SpacePort>> GetSpacePortById(int id)
        {
            var spacePort = _dbContext.SpacePorts.Find(id);

            if (spacePort == null)
            {
                return NotFound("That id doesn't exist");
            }

            return spacePort;
        }

        [HttpPost]
        public IActionResult PostSpacePort([FromBody] SpacePort spacePort)
        {
            var admin = _dbContext.Users.Where(u => u.Username == spacePort.UserName).Any(u => u.IsAdmin == true);

            if (admin == false)
            {
                return BadRequest("You have not permission to add a spaceport");
            }

            if(string.IsNullOrEmpty(spacePort.Name))
            {
                return BadRequest($"You need to enter a name for the spaceport.");
            }

            if (spacePort.ParkingSpots <= 0)
            {
                return BadRequest($"A spaceport needs a minimum of 1 parking spots.");
            }

            _dbContext.SpacePorts.Add(spacePort);
            _dbContext.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, "You have created a space port");
        }

    }
}
