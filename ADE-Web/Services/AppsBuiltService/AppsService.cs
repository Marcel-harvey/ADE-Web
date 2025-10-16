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
        public async Task UpdateApp(UpdateAppsBuiltViewModel model)
        {
            var updateApp = await _context.appsBuilt
                .Include(app => app.appImprovements)
                .FirstOrDefaultAsync(app => app.Id == model.AppId);

            if (updateApp == null)
                throw new KeyNotFoundException($"App with ID: {model.AppId} was not found");

            // Update app properties
            updateApp.AppName = model.AppName;
            updateApp.AppGitHubUrl = model.AppGitHubUrl;
            updateApp.AppDescription = model.AppDescription;

            // Get IDs of submitted improvements
            var submittedIds = model.Improvements
                                    .Where(i => i.Id != 0)
                                    .Select(i => i.Id)
                                    .ToList();

            // Remove improvements that exist in DB but were deleted in the modal
            var toRemove = updateApp.appImprovements
                                    .Where(i => !submittedIds.Contains(i.Id))
                                    .ToList();

            foreach (var rem in toRemove) 
                _context.appImprovement.Remove(rem);

            // Add or update submitted improvements
            foreach (var improvementModel in model.Improvements)
            {
                if (improvementModel.Id == 0)
                {
                    // New improvement
                    var newImprovement = new AppImprovementModel
                    {
                        Improvement = improvementModel.Improvement,
                        AppsBuiltId = updateApp.Id
                    };
                    updateApp.appImprovements.Add(newImprovement);
                }
                else
                {
                    // Existing improvement
                    var existingImprovement = updateApp.appImprovements
                        .FirstOrDefault(imp => imp.Id == improvementModel.Id);

                    if (existingImprovement != null)
                        existingImprovement.Improvement = improvementModel.Improvement;
                }
            }

            await _context.SaveChangesAsync();
        }


        // Delete app using Id - return none
        public async Task DeleteApp(int id)
        {
            var deleteApp = await _context.appsBuilt.FindAsync(id);

            if (deleteApp == null)
            {
                throw new KeyNotFoundException($"App with ID: {id} was not found");
            }

            _context.appsBuilt.Remove(deleteApp);

            await _context.SaveChangesAsync();
        }
    }
}
