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

        [HttpGet]
        public IEnumerable<Pay> Get()
        {
            return _dbContext.Payments;
        }

        [HttpGet("{id}")]
        public ActionResult<Pay> GetPayments(int id)
        {
            var payment = _dbContext.Payments.Find(id);

            if (payment == null)
            {
                return NotFound("That payment doesn't exist!");
            }

            return payment;
        }

        //[HttpPost]
        //public ActionResult<Pay> PostPayment([FromBody] Pay pay)
        //{
        //    var payments = from payment in _dbContext.Payments
        //                   join parking in _dbContext.Parkings on payment.Parkings equals parking.Id
        //                   select new
        //                   {
        //                       Id = pay.Id,
        //                       EndTime = payment.EndTime,
        //                       Price = payment.Price
        //                   };

        //    payments.
        //}


        [HttpPost]
        public IActionResult PostPayment([FromBody] Pay pay)
        {
            //var q = (from p in _dbContext.Parkings
            //         join payment in _dbContext.Payments
            //             on p.Id equals payment.ParkId
            //         where p.Id == payment.ParkId
            //         select new
            //         {
            //             Id = p.Id,
            //             ArrivalTime = p.ArrivalTime

            //         }).FirstOrDefault();

            var findparking = _dbContext.Parkings.FirstOrDefault(p => p.Id == pay.ParkId);


                pay.ArrivalTime = findparking.ArrivalTime;
                pay.EndTime = DateTime.Now;
                TimeSpan timeParked = (TimeSpan) (pay.EndTime - findparking.ArrivalTime);

                
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
