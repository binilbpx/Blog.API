using Blog.API.Controllers;
using Blog.API.Models;
using Blog.API.Services;
using Moq;
using System;
using Xunit;

namespace Blog.API.Tests
{
    public class UnitTest_User
    {
        #region Property  
        public Mock<IUserService> mock = new Mock<IUserService>();
        #endregion

        [Fact]
        public async void SaveTest_Success()
        {
            var userDTO = new User()
            {
                Name = "Test Name",
                Email = "test@gmail.com",
                Phone = "1234567890",
                UserName = "testname",
                Password = "1234abcd",
                CreatedDate = DateTime.Now
            };

            var returnUserDTO = new User()
            {
                Id = 1,
                Name = userDTO.Name,
                Email = userDTO.Email,
                Phone = userDTO.Phone,
                UserName = userDTO.UserName,
                Password = userDTO.Password,
                CreatedDate = userDTO.CreatedDate
            };

            mock.Setup(p => p.SaveUser(userDTO)).ReturnsAsync(returnUserDTO);
            UserController testController = new UserController(mock.Object);
            var result = await testController.SaveTest(userDTO);
            Assert.True(returnUserDTO.Id > 0);
        }
    }
}
