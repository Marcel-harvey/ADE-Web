using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;

namespace ADE_Web.Services.TechStackService
{
    public interface  ITechService
    {
        List<TechStackModel> GetAllTech();
        TechStackModel? GetTech(int id);
        Task AddTech(CreateTechStackBiewModel tech);
        Task UpdateTech(UpdateTechStackViewModel tech);
        Task DeleteTech(int id);
    }
}
