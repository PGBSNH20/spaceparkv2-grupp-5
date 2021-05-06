//using System;
//using System.Reflection.Metadata;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using NUnit.Framework;
//using SpaceParkAPI;
//using SpaceParkAPI.Controllers;
//using SpaceParkAPI.Data;
//using SpaceParkAPI.Models;
//using Xunit;

//namespace TestProject3
//{
//    public class UnitTest1
//    {

//        private static DbContextOptions<SpaceDbContext> options = new DbContextOptionsBuilder<SpaceDbContext>()
//            .UseInMemoryDatabase(databaseName: "Test")
//            .Options;

//        private static SpaceDbContext _dbContext;
//        private static ParkingsController parkings = new ParkingsController(_dbContext);




//        public void SeedDataBase()
//        {
            
//        }

//        [SetUp]
//        public async Task PostUser_ValidUser_ExpectTrue()
//        {

//            Swapi test = new Swapi();

//            User user = new User()
//            {
//                Id = 1,
//                PersonName = "Luke Skywalker",
//                Username = "youngjedi",
//                Password = "secret123",
//                IsAdmin = false
//            };

//            var result = await test.ValidateName(user.PersonName);

//            Assert.True(result);
//        }

//        [Fact]
//        public async Task PostUser_InValidUser_ExpectFalse()
//        {
//            Swapi test = new Swapi();

//            User user = new User()
//            {
//                Id = 1,
//                PersonName = "Morgan Freeman",
//                Username = "youngjedi",
//                Password = "secret123",
//                IsAdmin = false
//            };

//            var result = await test.ValidateName(user.PersonName);

//            Assert.False(result);
//        }

//        [Fact]
//        public void Test1()
//        {
//            SpacePort spacePort = new SpacePort()
//            {
//                Id = 1,
//                Name = "Uddevalla Space Port",
//                ParkingSpots = 3,
//                UserName = "admin"
//            };

//            var result = false;

//            if (spacePort.UserName == "admin")
//            {
//                result = true;
//            }

//            Assert.True(result);
//        }


//    }
//}
