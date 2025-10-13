using ADE_Web.Data;
using ADE_Web.Models;
using ADE_Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADE_Web.Controllers
{
    public class FreelancingController : Controller
    {
        public FreelancingController() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
