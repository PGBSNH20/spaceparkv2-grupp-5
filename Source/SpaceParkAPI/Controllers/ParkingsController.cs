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
        public IActionResult Get()
        {
            var query = (from s in _dbContext.SpacePorts
                         join p in _dbContext.Parkings
                             on s.Id equals p.SpacePortId
                         where s.Id == p.SpacePortId
                         select new
                         {
                             SpacePortId = s.Id,
                             SpacePortName = s.Name,
                             PersonName = p.PersonName,
                             Ship = p.SpaceShip,
                             ArrivalTime = p.ArrivalTime,
                         }).ToList();

            return Ok(query);
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
            bool validSpacePortId = _dbContext.SpacePorts.Any(s => s.Id == park.SpacePortId);
            var currentSpacePort = _dbContext.SpacePorts.Where(s => s.Id == park.SpacePortId).FirstOrDefault();

            bool validName = false;
            validName = await Swapi.ValidateName(park.PersonName);
            bool validShip = false;
            validShip = await Swapi.ValidateSpaceShip(park.SpaceShip);

            var query = _dbContext.Parkings
                .Where(p => p.PersonName == park.PersonName)
                .OrderByDescending(p => p.Id)
                .Select(p => p.Payed == false).FirstOrDefault();

            if (validName == false)
            {
                return NotFound("You entered an invalid name");
            }

            if (validShip == false)
            {
                return BadRequest("You entered an invalid spaceship/spaceship was too big for the SpacePort");
            }

            if (query && validName)
            {
                return BadRequest("You must pay your current parking first");
            }

            if(park.SpacePortId <= 0 || !validSpacePortId)
            {
                return BadRequest("You have to enter a valid SpacePortId.");
            } 

            if(currentSpacePort.ParkingSpots < 1)
            {
                return BadRequest("Sorry, the parking is occupied. Please come back later.");
            }

            park.ArrivalTime = DateTime.Now;


            currentSpacePort.ParkingSpots--;
            await _dbContext.Parkings.AddAsync(park);
            await _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
