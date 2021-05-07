using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Controllers
{
    [ApiKeyAuth]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private SpaceDbContext _dbContext;

        public PaymentsController(SpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        

        // GET all payments in the Database including parking.
        [HttpGet]
        public IActionResult GetAllPayments()
        {
            var query = (from p in _dbContext.Parkings
                         join payment in _dbContext.Payments
                             on p.Id equals payment.ParkId
                         where p.Id == payment.ParkId
                         select new
                         {
                             ParkingId = payment.Id,
                             PersonName = p.UserName,
                             Ship = p.SpaceShip,
                             ArrivalTime = p.ArrivalTime,
                             EndTime = payment.EndTime,
                             Price = payment.Price

                         }).ToList();

            return Ok(query);
        }

        // GET payment by ParkId.
        [HttpGet("{id}")]
        public IActionResult GetPaymentByParkId(int id)
        {
            var parking =  _dbContext.Payments.Find(id);

            if (parking == null)
            {
                return NotFound("That payment doesn't exist!");
            }


            var query = (from p in _dbContext.Parkings
                         join payment in _dbContext.Payments
                             on p.Id equals payment.ParkId
                         where p.Id == id
                         select new
                         {
                             ParkingId = payment.Id,
                             UserName = p.UserName,
                             Ship = p.SpaceShip,
                             ArrivalTime = p.ArrivalTime,
                             EndTime = payment.EndTime,
                             Price = payment.Price

                         }).ToList();

           

            return Ok(query);
        }

        // POST (and finish a parking) payment
        [HttpPost]
        public IActionResult PostPayment([FromBody] Pay pay)
        {
            var paidParking = _dbContext.Parkings.FirstOrDefault(p => p.Id == pay.ParkId);
            var currentSpacePort = _dbContext.SpacePorts.FirstOrDefault(s => s.Id == paidParking.SpacePortId);
            var parkingExist = _dbContext.Parkings.Any(p => p.Id == pay.ParkId);
            

            pay.EndTime = DateTime.Now;
            TimeSpan timeParked = (TimeSpan)(pay.EndTime - paidParking.ArrivalTime);

            pay.Price = timeParked.Minutes * 10;

            if (paidParking.Paid == true)
            {
                return BadRequest("The parking is already payed");
            }

            if (!parkingExist)
            {
                return BadRequest("There is no parking with this id");
            }

            paidParking.Paid = true;
            currentSpacePort.ParkingSpots++;

            //Add a parkingspot to the space port
            _dbContext.Payments.Add(pay);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, "Payment is done");

        }
    }
}
