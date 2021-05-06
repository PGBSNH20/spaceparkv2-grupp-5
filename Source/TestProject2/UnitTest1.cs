using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;
using SpaceParkAPI.Services;
using SpaceParkAPI.ViewModels;
using Xunit;
using Assert = Xunit.Assert;

namespace TestProject2
{
    public class UnitTest1
    {

        private static DbContextOptions<SpaceDbContext> options = new DbContextOptionsBuilder<SpaceDbContext>()
            .UseInMemoryDatabase(databaseName: "Test")
            .Options;
        
        SpaceDbContext context;
        private UsersService usersService;
        

        [OneTimeSetUp]

        public void SetUp()
        {
            context = new SpaceDbContext(options);
            context.Database.EnsureCreated();

            SeedDataBase();

            usersService = new UsersService(context);
        }

        
        public void SeedDataBase()
        {
            var users = new List<User>
            {
                new()
                {
                    Id = 1,
                    PersonName = "Luke Skywalker",
                    Username = "youngjedi",
                    Password = "secret123",
                    IsAdmin = false
                }
                  

                
                


        };
            context.Users.AddRange(users);
            context.SaveChanges();
        }

        [Fact]
        public void Test1()
        {
            User user = new User();

            var result = usersService.GetAllUsers();


            Assert.True(result.Count == 1);
        }

        [Fact]
        public void Test2()
        {
            UserVM user = new UserVM();

            var result = usersService.AddUser(user);

            

            Assert.True(result != null);
        }

    }
}
