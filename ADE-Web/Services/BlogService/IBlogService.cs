using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;

namespace ADE_Web.Services.BlogService
{
    public interface IBlogService
    {
        List<BlogModel> GetAllBlogs();
        BlogModel? GetBlog(int id);
        Task AddBlog (CreateBlogViewModel model);
        Task UpdateBlog(UpdateBlogViewModel model);
        Task DeleteBlog(int id);
    }
}
