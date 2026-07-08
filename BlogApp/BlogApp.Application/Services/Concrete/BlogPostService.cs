using BlogApp.Application.DTOs.Blog;
using BlogApp.Application.Services.Abstract;
using BlogApp.Core.Results;
using BlogApp.Data;
using BlogApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Application.Services.Concrete
{
    public class BlogPostService(AppDbContext context) : IBlogPostService
    {
        public async Task<Result<List<BlogPostDto>>> GetAllBlogPosts()
        {
            var blogPosts = await context.BlogPosts
                .Include(bp => bp.Category)
                .Include(bp => bp.Author)
                .Select(bp => new BlogPostDto
                {
                    Id = bp.Id,
                    Title = bp.Title,
                    Content = bp.Content,
                    AuthorId = bp.AuthorId,
                    AuthorFullName = $"{bp.Author.FirstName} {bp.Author.LastName}",
                    CategoryId = bp.CategoryId,
                    CategoryName = bp.Category.Name,
                    CreatedAt = bp.CreatedAt,
                }).ToListAsync();

            return Result<List<BlogPostDto>>.Ok(blogPosts);

        }

        public async Task<Result<List<CategoryDto>>> GetAllCategories()
        {
            var categories = await context.Categories
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                }).ToListAsync();

            return Result<List<CategoryDto>>.Ok(categories);

        }

        public async Task<Result> CreateBlogPost(CreateBlogPostRequest request)
        {
            var user = await context.Users.FindAsync(request.AuthorId);

            if (user is null || !user.IsActive)
                return Result.Fail("Author not found or inactive.");

            var blogPost = new BlogPost
            {
                Title = request.Title,
                Content = request.Content,
                AuthorId = request.AuthorId,
                CategoryId = request.CategoryId,
                CreatedAt = DateTime.UtcNow
            };

            context.BlogPosts.Add(blogPost);
            await context.SaveChangesAsync();
            return Result.Ok();
        }

        public Task<Result<BlogPostDto>> GetBlogPostById(int id)
        {
            throw new NotImplementedException();
        }




    }
}
