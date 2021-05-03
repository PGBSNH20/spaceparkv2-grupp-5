using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;

namespace SpaceParkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private SpaceDbContext _dbContext;

        public PaymentsController(SpaceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Get all payments in the Database including parking.
        [HttpGet]
        public IActionResult Get()
        {
            var query = (from p in _dbContext.Parkings
                         join payment in _dbContext.Payments
                             on p.Id equals payment.ParkId
                         where p.Id == payment.ParkId
                         select new
                         {
                             ParkingId = payment.Id,
                             PersonName = p.PersonName,
                             Ship = p.SpaceShip,
                             ArrivalTime = p.ArrivalTime,
                             EndTime = payment.EndTime,
                             Price = payment.Price

                         }).ToList();

            return Ok(query);
        }

        // Get payments by Id.
        [HttpGet("{id}")]
        public IActionResult GetPayments(int id)
        {
            var query = (from p in _dbContext.Parkings
                         join payment in _dbContext.Payments
                             on p.Id equals payment.ParkId
                         where p.Id == id
                         select new
                         {
                             ParkingId = payment.Id,
                             PersonName = p.PersonName,
                             Ship = p.SpaceShip,
                             ArrivalTime = p.ArrivalTime,
                             EndTime = payment.EndTime,
                             Price = payment.Price

                         }).ToList();

            if (query == null)
            {
                return NotFound("That payment doesn't exist!");
            }

            return Ok(query);
        }

        // Finish parking by creating a payment
        [HttpPost]
        public IActionResult PostPayment([FromBody] Pay pay)
        {
            var findparking = _dbContext.Parkings.FirstOrDefault(p => p.Id == pay.ParkId);

            pay.EndTime = DateTime.Now;
            TimeSpan timeParked = (TimeSpan)(pay.EndTime - findparking.ArrivalTime);

            pay.Price = timeParked.Minutes * 10;

            if (findparking.Payed == true)
            {
                return BadRequest("The parkings is already payed");
            }

            findparking.Payed = true;


            _dbContext.Payments.Add(pay);
            _dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, "Payment is done");


        }

    }
}
