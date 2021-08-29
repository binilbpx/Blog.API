using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Services
{
    public interface IUserService
    {
        public Task<User> SaveUser(User uesr);
        public Task<User> GetUser(int id);
        public Task<bool> ValidateUser(User uesr);
    }
}
