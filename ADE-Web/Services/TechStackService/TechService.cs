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
        public async Task UpdateTech(UpdateTechStackViewModel model)
        {
            var updateTechStack = await _context.techStack.FindAsync(model.TechStackId);

            if (updateTechStack == null)
            {
                throw new KeyNotFoundException($"Tech Stack with ID: {model.TechStackId} was not found");
            }

            updateTechStack.Language = model.Language;
            updateTechStack.Proficiency = model.Proficiency;

            await _context.SaveChangesAsync();
        }


        // Delete tech using ID - returns none
        public async Task DeleteTech(int id)
        {
            var deleteTechStack = await _context.techStack.FindAsync(id);

            if (deleteTechStack == null)
            {
                throw new KeyNotFoundException($"Tech Stack with ID: {id} was not found");
            }

            _context.Remove(deleteTechStack);
            await _context.SaveChangesAsync();
        }
    }
}
