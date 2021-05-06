using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SpaceParkAPI.Controllers;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUnitTestProject
{
    public class Tests
    {
        private static DbContextOptions<SpaceDbContext> options = new DbContextOptionsBuilder<SpaceDbContext>()
           .UseInMemoryDatabase(databaseName: "TestDatabase")
           .Options;

        private static SpaceDbContext _dbContext;
        private static ParkingsController parkings;
        private static UsersController users;
        private static SpacePortsController spacePorts;
        private static PaymentsController payments;

        [OneTimeSetUp]
        public void Setup()
        {
            _dbContext = new SpaceDbContext(options);
            _dbContext.Database.EnsureCreated();

            SeedDatabase();
            parkings = new ParkingsController(_dbContext);
            users = new UsersController(_dbContext);
            spacePorts = new SpacePortsController(_dbContext);
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _dbContext.Database.EnsureDeleted();
        }

        private void SeedDatabase()
        {
            var parkings = new Park
            {
                Id = 1,
                UserName = "youngjedi",
                SpaceShip = "X-wing",
                ArrivalTime = DateTime.Now,
                Paid = false,
                SpacePortId = 1
            };

            var user1 = new User
            {
                Id = 1,
                PersonName = "Luke Skywalker",
                Username = "youngjedi",
                Password = "secret123",
                IsAdmin = false
            };

            var user2 = new User
            {
                Id = 2,
                PersonName = "Boba Fett",
                Username = "fatboy",
                Password = "secret123",
                IsAdmin = false
            };

            var spacePorts = new SpacePort
            {
                Id = 1,
                Name = "KevinsSpacePort",
                ParkingSpots = 2,
                UserName = "admin"
            };

            var payments = new Pay
            {
                ParkId = 1
            };

            _dbContext.Parkings.AddRange(parkings);
            _dbContext.Users.AddRange(user1);
            _dbContext.Users.AddRange(user2);
            _dbContext.SpacePorts.AddRange(spacePorts);
            _dbContext.Payments.AddRange(payments);
            _dbContext.SaveChanges();
        }



        [Test]
        public async Task PostParking_AddValidParking_Expect201Created()
        {
            var newParking = new Park()
            {
                UserName = "fatboy",
                SpaceShip = "X-wing",
                SpacePortId = 1
            };

            ActionResult actionResult = await parkings.Post(newParking);
            var okResult = actionResult as ObjectResult;

            Assert.AreEqual(StatusCodes.Status201Created, okResult.StatusCode);
        }

        [Test]
        public async Task PostParking_AddParkingWhileUserAlreadyIsParked_Expect400BadRequest()
        {
            var newParking = new Park()
            {
                UserName = "youngjedi",
                SpaceShip = "X-wing",
                SpacePortId = 1
            };

            ActionResult actionResult = await parkings.Post(newParking);
            var okResult = actionResult as ObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);
        }

        [Test]
        public async Task PostUser_AddingUser_Expect201Created()
        {
            var newUser = new User()
            {
                PersonName = "Darth Vader",
                Username = "badboy",
                Password = "secret123",
            };

            ActionResult actionResult = await users.Post(newUser);
            var okResult = actionResult as ObjectResult;

            Assert.AreEqual(StatusCodes.Status201Created, okResult.StatusCode);
        }

        [Test]
        public async Task PostUser_InvalidPersonName_Expect404NotFound()
        {
            var newUser = new User()
            {
                PersonName = "Calle",
                Username = "youngjedi",
                Password = "secret123",
            };

            ActionResult actionResult = await users.Post(newUser);
            var okResult = actionResult as ObjectResult;

            Assert.AreEqual(StatusCodes.Status404NotFound, okResult.StatusCode);
        }

        [Test]
        public async Task PostUser_AddingExistingUser_Expect400BadRequest()
        {
            var newUser = new User()
            {
                PersonName = "Luke Skywalker",
                Username = "youngjedi",
                Password = "secret123",
            };

            ActionResult actionResult = await users.Post(newUser);
            var okResult = actionResult as ObjectResult;

            Assert.AreEqual(StatusCodes.Status400BadRequest, okResult.StatusCode);
        }



        
    }
}