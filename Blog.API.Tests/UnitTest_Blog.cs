using Blog.API.Controllers;
using Blog.API.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Blog.API.Tests
{
    public class UnitTest_Blog
    {
        #region Property  
        public Mock<IBlogService> mock = new Mock<IBlogService>();
        #endregion

        [Fact]
        public async void SaveBlog_Test()
        {
            var blogDTO = new Models.Blog()
            {
                Name = "Test Blog",
                Content = "test",
                Title = "test",
                CreatedUserId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var returnBlogDTO = new Models.Blog()
            {
                Id = 1,
                Name = blogDTO.Name,
                Content = blogDTO.Content,
                Title = blogDTO.Title,
                CreatedUserId = blogDTO.CreatedUserId,
                CreatedDate = blogDTO.CreatedDate,
                UpdatedDate = blogDTO.UpdatedDate
            };

            mock.Setup(p => p.CreateBlog(blogDTO)).ReturnsAsync(returnBlogDTO);
            BlogController blogController = new BlogController(mock.Object);
            var result = await blogController.SaveBlog(blogDTO);
            Assert.True(result.Id > 0);
        }

        [Fact]
        public async void SaveBlogComment_Test()
        {
            var blogCommentDTO = new Models.BlogComment()
            {
                Comment = "Test comment",
                CreatedUserId = 1,
                BlogId = 1
            };

            var returnBlogCommentDTO = new Models.BlogComment()
            {
                Id = 1,
                Comment = blogCommentDTO.Comment,
                CreatedUserId = blogCommentDTO.CreatedUserId,
                BlogId = blogCommentDTO.BlogId
            };

            mock.Setup(p => p.CreateComment(blogCommentDTO)).ReturnsAsync(returnBlogCommentDTO);
            BlogController blogController = new BlogController(mock.Object);
            var result = await blogController.SaveComment(blogCommentDTO);
            Assert.True(returnBlogCommentDTO.Id > 0);
        }
    }
}
