using Microsoft.AspNetCore.Mvc;

namespace ADE_Web.Controllers
{
    public class PotentialEmployer : Controller
    {
        public PotentialEmployer() { }

        public IActionResult Index()
        {
            return View();
        }
    }
}
