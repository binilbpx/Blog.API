using Blog.API.Models;
using Blog.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        #region Property  
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        #endregion

        #region Constructor  
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        #endregion

        /// <summary>
        /// Method to create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("/user/save")]
        public async Task<User> SaveTest([FromBody] User user)
        {
            var result = await _userService.SaveUser(user);

            return result;
        }

        /// <summary>
        /// Login the user by creating application pool identities
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("/user/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var result = await _userService.ValidateUser(user);

            if (result)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}
