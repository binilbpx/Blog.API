using Blog.API.Models;
using Blog.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    public class BlogController : Controller
    {
        #region Property  
        private readonly IBlogService _blogService;
        #endregion

        #region Constructor  
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
        #endregion

        [HttpPost("/blog/save")]
        public async Task<Models.Blog> SaveBlog([FromBody] Models.Blog blog)
        {
            var result = await _blogService.CreateBlog(blog);

            return result;
        }

        [HttpPost("/blog/comment/save")]
        public async Task<BlogComment> SaveComment([FromBody] BlogComment blogComment)
        {
            var result = await _blogService.CreateComment(blogComment);

            return result;
        }
    }
}
