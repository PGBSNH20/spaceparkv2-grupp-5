using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParksController : ControllerBase
    {
        private readonly SpaceDbContext _context;

        public ParksController(SpaceDbContext context)
        {
            _context = context;
        }

        // GET: api/Parks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Park>>> GetParkings()
        {
          

            
            return await _context.Parks.ToListAsync();
        }

        // GET: api/Parks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Park>> GetPark(int id)
        {
            var park = await _context.Parks.FindAsync(id);

            if (park == null)
            {
                return NotFound();
            }

            return park;
        }

        // PUT: api/Parks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPark(int id, Park park)
        {
            if (id != park.Id)
            {
                return BadRequest();
            }

            _context.Entry(park).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParkExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Parks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Park>> PostPark([FromBody]Park park)
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

            
            
            park.ArrivalTime = DateTime.Now;
            

            _context.Parks.Add(park);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPark", new { id = park.Id }, park);
        }

        // DELETE: api/Parks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePark(int id)
        {
            var park = await _context.Parks.FindAsync(id);
            if (park == null)
            {
                return NotFound();
            }

            _context.Parks.Remove(park);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ParkExists(int id)
        {
            return _context.Parks.Any(e => e.Id == id);
        }
    }
}
