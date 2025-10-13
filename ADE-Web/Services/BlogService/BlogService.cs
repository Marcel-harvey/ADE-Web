using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;

namespace ADE_Web.Services.BlogService
{
    public class BlogService : IBlogService
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // Get all blogs
        public List<BlogModel> GetAllBlogs() => _context.blog.ToList();


        // Get blog via ID
        public BlogModel? GetBlog(int id) => _context.blog.FirstOrDefault();


        // Create new blog
        public async Task AddBlog(CreateBlogViewModel model)
        {
            var blog = new BlogModel
            {
                BlogTitle = model.BlogTitle,
                BlogContent = model.BlogContent,
                DatePosted = DateTime.Now,
            };

            _context.blog.Add(blog);
            await _context.SaveChangesAsync();
        }


        // Update blog
        public void UpdateBlog(BlogModel model)
        {
            _context.blog.Remove(model);
        }


        // DeleteBlog using ID
        public void DeleteBlog(int id)
        {
            var deleteBlog = _context.blog.FirstOrDefault(blog => blog.Id == id);

            if (deleteBlog != null)
            {
                _context.blog.Remove(deleteBlog);
                _context.SaveChanges();
            }
        }
    }
}
