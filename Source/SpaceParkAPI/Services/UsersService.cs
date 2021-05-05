using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceParkAPI.Data;
using SpaceParkAPI.Models;
using SpaceParkAPI.ViewModels;

namespace SpaceParkAPI.Services
{
    public class UsersService
    {
        private SpaceDbContext _DbContext;

        public UsersService(SpaceDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        
        public async Task AddUser(UserVM user)
        {
            var usersExist = _DbContext.Users.Any(p => p.PersonName == user.PersonName);
            
            bool validName = false;
            validName = await Swapi.ValidateName(user.PersonName);



            //if (validName == false)
            //{
                

            //}

            if (usersExist)
            {
                throw new("You can't create multiple users");
            }

            if (string.IsNullOrEmpty(user.Password) || string.IsNullOrEmpty(user.UserName))
            {
                throw new("You password or username is empty");
                
            }

            var _user = new User()
            {
                PersonName = user.PersonName,
                Username = user.UserName,
                Password = user.Password,
            };

            _DbContext.Users.Add(_user);
            _DbContext.SaveChanges();


        }
    }
}
