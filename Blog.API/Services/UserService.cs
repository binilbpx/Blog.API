using Blog.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Services
{
    public class UserService : IUserService
    {
        #region Property  
        private readonly RepositoryContext _repositoryContext;
        #endregion

        #region Constructor  
        public UserService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        #endregion

        public async Task<User> SaveUser(User user)
        {
            _repositoryContext.Users.Add(user);
            _repositoryContext.SaveChanges();

            return user;
        }

        public async Task<User> GetUser(int id)
        {
            return _repositoryContext.Users.Where(c => c.Id == id).FirstOrDefault();
        }

        public async Task<bool> ValidateUser(User user)
        {
            var result =  _repositoryContext.Users.Where(c => 
            c.UserName == user.UserName && c.Password == user.Password).
            FirstOrDefault();

            if (result.Id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
