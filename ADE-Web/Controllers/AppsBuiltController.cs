using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Services.AppsBuiltService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ADE_Web.Controllers
{
    public class AppsBuiltController : Controller
    {
        // Dependancy injection for API services - ADE_Web/Service
        private readonly IAppsService _appsService;
        private readonly ApplicationDbContext _context;

        public AppsBuiltController(ApplicationDbContext context, IAppsService appsService)
        {
            _context = context;
            _appsService = appsService;
        }

        // UI Actions
        // GET: View all apps built
        public IActionResult Index()
        {
            var apps = _appsService.GetAllApps();
            return View(apps);
        }


        // API Actions
        // Create a new app - returns Status 200 if success
        [HttpPost("api/apps/{app}")]
        public IActionResult CreateApp(AppsBuiltModel app)
        {
            if (app == null)
            {
                return NotFound();
            }


            return Ok();
        }

    }
}
