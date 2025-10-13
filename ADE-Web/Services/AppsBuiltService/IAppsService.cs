using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using System.Collections.Generic;

namespace ADE_Web.Services.AppsBuiltService
{
    public interface IAppsService
    {
        List<AppsBuilt> GetAllApps();
        AppsBuilt? GetApp(int id);
        Task AddApp(CreateAppsBuildViewModel model);
        void UpdateApp(AppsBuilt app);
        void DeleteApp(int id);
    }
}
