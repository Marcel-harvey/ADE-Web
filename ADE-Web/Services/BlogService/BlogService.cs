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
        public async Task UpdateBlog(UpdateBlogViewModel model)
        {
            var updateBlog = await _context.blog.FindAsync(model.BlogId);

            if (updateBlog == null)
            {
                throw new KeyNotFoundException($"Blog with ID {model.BlogId} not found.");
            }

            updateBlog.BlogTitle = model.BlogTitle;
            updateBlog.BlogContent = model.BlogContent;

            await _context.SaveChangesAsync();
        }


        // DeleteBlog using ID
        public async Task DeleteBlog(int id)
        {
            var deleteBlog = await _context.blog.FindAsync(id);


            if (deleteBlog == null)
            {
                throw new KeyNotFoundException($"Blog with ID {id} not found.");
            }

            _context.blog.Remove(deleteBlog);
            await _context.SaveChangesAsync();
        }
    }
}
