using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using ADE_Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ADE_Web.Controllers
{
    public class DashboardController :Controller
    {
        private readonly IAppsService _appsService;
        private readonly ApplicationDbContext _context;

        public DashboardController(IAppsService appsService, ApplicationDbContext context)
        {
            _appsService = appsService;
            _context = context;
        }

        // View all current apps
        public IActionResult Index()
        {
            var apps = _appsService.GetAllApps();

            return View(apps);
        }

        // GET: Create a new app
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create a new app
        [HttpPost]
        public async Task<IActionResult> Create(CreateAppsBuildViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _appsService.AddApp(model);

            TempData["Success"] = "App created successfully!";
            return RedirectToAction(nameof(Index));            
        }

    }
}
