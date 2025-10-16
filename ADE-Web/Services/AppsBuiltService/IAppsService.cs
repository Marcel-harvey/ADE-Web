using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using System.Collections.Generic;

namespace ADE_Web.Services.AppsBuiltService
{
    public interface IAppsService
    {
        List<AppsBuiltModel> GetAllApps();
        AppsBuiltModel? GetApp(int id);
        Task AddApp(CreateAppsBuildViewModel model);
        Task UpdateApp(UpdateAppsBuiltViewModel app);
        Task DeleteApp(int id);
    }
}
