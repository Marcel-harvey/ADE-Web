using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


// Service layer that can be injected everywhere in app
namespace ADE_Web.Services.AppsBuiltService
{
    public class AppsService : IAppsService
    {
        private readonly ApplicationDbContext _context;

        public AppsService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all apps
        public List<AppsBuiltModel> GetAllApps() => _context.appsBuilt.Include(apps => apps.appImprovements).ToList();


        // Get app via ID
        public AppsBuiltModel? GetApp(int id) => _context.appsBuilt.Include(app => app.appImprovements).FirstOrDefault();


        // Add app to model - returns none
        public async Task AddApp(CreateAppsBuildViewModel model)
        {
            var app = new AppsBuiltModel
            {
                AppName = model.AppName,
                AppGitHubUrl = model.AppGitHubUrl,
                AppDescription = model.AppDescription
            };

            foreach (var impVm in model.Improvements ?? new List<CreateAppImprovementViewModel>())
            {
                var improvement = new AppImprovementModel
                {
                    Improvement = impVm.Improvement,
                    AppsBuilt = app
                };
                app.appImprovements.Add(improvement);
            }

            _context.appsBuilt.Add(app);
            await _context.SaveChangesAsync();
        }


        // Update app - returns none
        public void UpdateApp(AppsBuiltModel app)
        {
            _context.appsBuilt.Update(app);
            _context.SaveChanges();
        }


        // Delete app using Id - return none
        public void DeleteApp(int id)
        {
            var app = _context.appsBuilt.FirstOrDefault(app => app.Id == id);
            if (app != null)
            {
                _context.appsBuilt.Remove(app);
                _context.SaveChanges();
            }
        }
    }
}
