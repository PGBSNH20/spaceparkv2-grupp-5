using System;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using SpaceParkAPI;
using SpaceParkAPI.Models;
using Xunit;

namespace TestProject3
{
    public class UnitTest1
    {
        [Fact]
        public async Task PostUser_ValidInput_ExpectTrue()
        {
           
            Swapi test = new Swapi();

            User user = new User()
            {
                Id = 1,
                PersonName = "Luke Skywalker",
                Username = "youngjedi",
                Password = "secret123",
                IsAdmin = false
            };

            var result = await test.ValidateName(user.PersonName);

            Assert.True(result);
        }

        [Fact]
        public async Task PostUser_InValidInput_ExpectFalse()
        {
            Swapi test = new Swapi();

            User user = new User()
            {
                Id = 1,
                PersonName = "Morgan Freeman",
                Username = "youngjedi",
                Password = "secret123",
                IsAdmin = false
            };

            var result = await test.ValidateName(user.PersonName);

            Assert.False(result);
        }
    }
}
