using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Services
{
    public interface IBlogService
    {
        public Task<Models.Blog> CreateBlog(Models.Blog blog);
        public Task<BlogComment> CreateComment(BlogComment blogComment);
    }
}
