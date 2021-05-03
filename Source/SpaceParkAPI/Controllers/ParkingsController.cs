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
    public class ParkingsController : ControllerBase
    {
        private SpaceDbContext _dbContext;

        public ParkingsController(SpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET all parkings in the database.
        [HttpGet]
        public IEnumerable<Park> Get()
        {
            return _dbContext.Parkings;
        }

        //GET parkings by id.
        [HttpGet("{id}")]
        public async Task<ActionResult<Park>> GetParking(int id)
        {
            var parking = await _dbContext.Parkings.FindAsync(id);

            if (parking == null)
            {
                return NotFound("That parking doesn't exist");
            }

            return parking;
        }

        //POST new parking.
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Park park)
        {
            bool validName = false;
            validName = await Swapi.ValidateName(park.PersonName);
            bool validShip = false;
            validShip = await Swapi.ValidateSpaceShips(park.SpaceShip);

            

            if (validName == false)
            {
                return NotFound("You entered an invalid name");
            }

            if (validShip == false)
            {
                return NotFound("You entered an invalid spaceship");
            }

            if (park.Payed == true && validName)
            {
                return BadRequest("You must pay your current parking first");
            }

            park.ArrivalTime = DateTime.Now;

            _dbContext.Parkings.Add(park);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
