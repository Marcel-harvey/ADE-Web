using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ADE_Web.Services.TechStackService
{
    public class TechService : ITechService
    {
        private readonly ApplicationDbContext _context;

        public TechService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all tech stack
        public List<TechStackModel> GetAllTech()  => _context.techStack.ToList();


        // Get tech stack via ID
        public TechStackModel? GetTech(int id) => _context.techStack.FirstOrDefault();
        

        // Add tech to model - returns none
        public async Task AddTech(CreateTechStackBiewModel model)
        {
            var techStack = new TechStackModel
            {
                Language = model.Language,
                Proficiency = model.Proficiency
            };

            _context.techStack.Add(techStack);
            await _context.SaveChangesAsync();
        }


        // Update tech - returns none
        public void UpdateTech(TechStackModel tech)
        {
            _context.techStack.Update(tech);
            _context.SaveChanges();
        }


        // Delete tech using ID - returns none
        public void DeleteTech(int id)
        {
            var techStack = _context.techStack.FirstOrDefault(tech => tech.Id == id);

            if (techStack != null)
            {
                _context.techStack.Remove(techStack);
                _context.SaveChanges();
            }
        }
    }
}
