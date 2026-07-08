using BlogApp.Application.DTOs.Blog;
using BlogApp.Core.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Services.Abstract
{
    public interface IBlogPostService
    {
        Task<Result<List<BlogPostDto>>> GetAllBlogPosts();
        Task<Result<List<CategoryDto>>> GetAllCategories();

        Task<Result> CreateBlogPost(CreateBlogPostRequest request);
        Task <Result<BlogPostDto>>GetBlogPostById(int postId);

        //void GetAllBlogPostsByAuthorId(int authorId);
        //void GetBlogPostDetail(int blogPostId);
    }
}
