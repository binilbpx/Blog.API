using Blog.API.Models;
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
    }
}
