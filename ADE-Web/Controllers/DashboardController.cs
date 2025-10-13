using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using ADE_Web.Services.AppsBuiltService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ADE_Web.Controllers
{
    [Authorize]
    public class DashboardController :Controller
    {
        private readonly IAppsService _appsService;
        private readonly ApplicationDbContext _context;

        public DashboardController(IAppsService appsService, ApplicationDbContext context)
        {
            _appsService = appsService;
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction(nameof(ViewAppsBuilt));
        }


        // GET: View all current apps
        public IActionResult ViewAppsBuilt()
        {
            var apps = _appsService.GetAllApps();

            return View(apps);
        }


        // GET: View tech stack
        public IActionResult ViewTechStack()
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
            return RedirectToAction(nameof(Index));            
        }


        //GET: Create new tech stack
        public IActionResult CreateTechStack()
        {
            return View();
        }

    }
}
