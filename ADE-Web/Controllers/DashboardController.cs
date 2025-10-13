using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using ADE_Web.Services.AppsBuiltService;
using ADE_Web.Services.TechStackService;
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
        private readonly ApplicationDbContext _context;

        public DashboardController(IAppsService appsService,ITechService techService, ApplicationDbContext context)
        {
            _appsService = appsService;
            _techService = techService;
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

    }
}
