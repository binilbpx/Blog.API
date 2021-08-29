using Blog.API.Models;
using Blog.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Controllers
{
    [Authorize]
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

        /// <summary>
        /// Blogs will be created if Id == 0, otherwise, existing one will get updated
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [HttpPost("/blog/save")]
        public async Task<Models.Blog> SaveBlog([FromBody] Models.Blog blog)
        {
            var result = await _blogService.CreateBlog(blog);

            return result;
        }

        /// <summary>
        /// Any user can add comment without authorization
        /// </summary>
        /// <param name="blogComment"></param>
        /// <returns></returns>
        [HttpPost("/blog/comment/save")]
        [AllowAnonymous]
        public async Task<BlogComment> SaveComment([FromBody] BlogComment blogComment)
        {
            var result = await _blogService.CreateComment(blogComment);

            return result;
        }
    }
}
