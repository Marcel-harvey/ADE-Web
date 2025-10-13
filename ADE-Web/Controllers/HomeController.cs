using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Services.BlogService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ADE_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IBlogService _blogService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IBlogService blogService)
        {
            _logger = logger;
            _context = context;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var blog = _blogService.GetAllBlogs();

            return View(blog);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
