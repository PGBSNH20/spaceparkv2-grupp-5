using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;
using System;
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

        [HttpGet]
        public IEnumerable<SpacePort> GetAllSpacePorts()
        {
            return _dbContext.SpacePorts;
        }

        [HttpGet("{id}")]
        public IActionResult GetSpacePortById(int id)
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

        [HttpPost]
        public IActionResult PostSpacePort([FromBody] SpacePort spacePort)
        {
            if(string.IsNullOrEmpty(spacePort.Name))
            {
                return BadRequest($"You need to enter a name for the spaceport.");
            }

            if (spacePort.ParkingSpots <= 0)
            {
                return BadRequest($"A spaceport needs a minimum of 1 parking spots.");
            }

            _dbContext.SpacePorts.Add(spacePort);
            _dbContext.SaveChangesAsync();

            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
