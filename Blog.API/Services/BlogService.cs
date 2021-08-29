using Blog.API.Models;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Services
{
    public class BlogService: IBlogService
    {
        #region Property  
        private readonly RepositoryContext _repositoryContext;
        #endregion

        #region Constructor  
        public BlogService(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        #endregion

        /// <summary>
        /// Method for add and edit blogs. If id > 0, row will get updated
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        public async Task<Models.Blog> CreateBlog(Models.Blog blog)
        {
            if (blog.Id > 0)
            {
                var existingBlog = _repositoryContext.Blogs.Where(c => c.Id == blog.Id).FirstOrDefault();

                existingBlog.Comments = blog.Comments;
                existingBlog.Content = blog.Content;
                existingBlog.Name = blog.Name;
                existingBlog.Title = blog.Title;
                existingBlog.UpdatedDate = DateTime.Now;

                _repositoryContext.SaveChanges();
            }
            else
            {
                _repositoryContext.Blogs.Add(blog);
                _repositoryContext.SaveChanges();
            }            

            return blog;
        }

        [AllowAnonymous]
        public async Task<BlogComment> CreateComment(BlogComment blogComment)
        {
            _repositoryContext.BlogComments.Add(blogComment);
            _repositoryContext.SaveChanges();

            return blogComment;
        }
    }
}
