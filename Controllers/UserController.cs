using Blog.API.Models;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    public class UserController : Controller
    {
        #region Property  
        private readonly IUserService _userService;
        #endregion

        #region Constructor  
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        #endregion

        [HttpPost("/user/save")]
        public async Task<User> SaveTest([FromBody] User user)
        {
            var result = await _userService.SaveUser(user);

            return result;
        }
    }
}
