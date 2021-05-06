using System;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using SpaceParkAPI.Data;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    {

        




        private static DbContextOptions<SpaceDbContext> options = new DbContextOptionsBuilder<SpaceDbContext>()
            .UseInMemoryDatabase
                (databaseName: "Test")
            .Options;

         SpaceDbContext context;


         [OneTimeSetUp]
         public void SetUp()
         {

         }



        [Fact]
        public void Test1()
        {

        }
    }
}
