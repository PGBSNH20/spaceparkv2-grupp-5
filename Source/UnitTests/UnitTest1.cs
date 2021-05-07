using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SpaceParkAPI.Controllers;
using SpaceParkAPI.Data;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        private static DbContextOptions<SpaceDbContext> options = new DbContextOptions<SpaceDbContext>();
        private static SpaceDbContext _dbContext = new SpaceDbContext(options);
        private ParkingsController park = new ParkingsController(_dbContext);


            [Fact]
        public void Test1()
        {
            var result = park.Get();

            Assert.NotNull(result);
        }
    }
}
