using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using ADE_Web.Services.AppsBuiltService;
using ADE_Web.Services.TechStackService;
using ADE_Web.Services.BlogService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ADE_Web.Controllers
{
    [Authorize]
    public class DashboardController :Controller
    {
        private readonly IAppsService _appsService;
        private readonly ITechService _techService;
        private readonly IBlogService _blogService;
        private readonly ApplicationDbContext _context;

        public DashboardController(IAppsService appsService,ITechService techService,IBlogService blogService, ApplicationDbContext context)
        {
            _appsService = appsService;
            _techService = techService;
            _blogService = blogService;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(ViewAppsBuilt));
        }


        // ================ BUILT APPS SECTION ================
        // GET: View all current apps
        public IActionResult ViewAppsBuilt()
        {
            var apps = _appsService.GetAllApps();

            return View(apps);
        }


        // GET: Create a new app
        public IActionResult CreateAppsBuilt()
        {
            return View();
        }


        //POST: Create a new app
        [HttpPost]
        public async Task<IActionResult> CreateAppsBuilt(CreateAppsBuildViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _appsService.AddApp(model);

            TempData["Success"] = "App created successfully!";
            return RedirectToAction(nameof(ViewAppsBuilt));
        }


        // POST Update apps built
        [HttpPost]
        public async Task<IActionResult> UpdateAppsBuilt(UpdateAppsBuiltViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input");
            }

            try
            {
                await _appsService.UpdateApp(model);
                return Ok(new { message = "App updated successgully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // ================ TECH STACK SECTION ================
        // GET: View tech stack
        public IActionResult ViewTechStack()
        {
            var tech = _techService.GetAllTech();

            return View(tech);
        }


        //GET: Create new tech stack
        public IActionResult CreateTechStack()
        {
            return View();
        }


        // POST: Create new tech stack
        [HttpPost]
        public async Task<IActionResult> CreateTechStack(CreateTechStackBiewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _techService.AddTech(model);

            TempData["Success"] = "New Tech Stack created successfully!";
            return RedirectToAction(nameof(ViewTechStack));
        }


        // POST: Edit current Tech Stack item - done through AJAX on modal view
        [HttpPost]
        public async Task<IActionResult> UpdateTechStack(UpdateTechStackViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input");
            }

            try
            {
                await _techService.UpdateTech(model);
                return Ok(new { message = "Blog updated successgully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // POST: Delete current Tech Stack item - done through AJAX on modal view
        [HttpPost]
        public async Task<IActionResult> DeleteTechStack(int id)
        {
            try
            {
                await _techService.DeleteTech(id);
                return Ok(new { message = "Blog deleted successfully" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // ================ BLOG SECTION ================
        //GET: View all blogs
        public IActionResult ViewBlog()
        {
            var blog = _blogService.GetAllBlogs();

            return View(blog);
        }


        // GET: Create new blog
        public IActionResult CreateBlog()
        {
            return View();
        }

        // POST: Create new blog
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _blogService.AddBlog(model);
            TempData["Success"] = "New blog created successfully!";

            return RedirectToAction(nameof(ViewBlog));
        }


        // POST Edit current blog - done through AJAX on modal view
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Input");
            }

            try
            {
                await _blogService.UpdateBlog(model);
                return Ok(new {message = "Blog updated successgully"});
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }


        // POST: Delete current blog - done through AJAX on modal view
        [HttpPost]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                await _blogService.DeleteBlog(id);
                return Ok(new {message = "Blog deleted successfully"});
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
