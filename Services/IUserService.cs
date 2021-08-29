using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Services
{
    public interface IUserService
    {
        public Task<User> SaveUser(User uest);
    }
}
