using Microsoft.AspNetCore.Mvc;
using ADE_Web.Models;
using ADE_Web.Models.ViewModels;
using ADE_Web.Services.TechStackService;
using ADE_Web.Data;

namespace ADE_Web.Controllers
{
    public class PotentialEmployer : Controller
    {
        private readonly ITechService _techService;
        private readonly ApplicationDbContext _context;

        public PotentialEmployer(ITechService techService, ApplicationDbContext context) 
        {
            _techService = techService;
            _context = context;
        }

        public IActionResult Index()
        {
            var techStack = _techService.GetAllTech();

            return View(techStack);
        }
    }
}
