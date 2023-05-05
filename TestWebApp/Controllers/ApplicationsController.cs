using Microsoft.AspNetCore.Mvc;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class ApplicationsController : Controller
    {
        private readonly ILogger<ApplicationsController> _logger;
        public ApplicationsVM applicationsVM = new ApplicationsVM();

        public ApplicationsController(ILogger<ApplicationsController> logger, JobTrackerDbContext db)
        {
            _logger = logger;
            applicationsVM.applicationList = db.Applications;
            applicationsVM.jobDescList = db.JobDescs;
        }

        public IActionResult index()
        {
            return View(applicationsVM);
        }
    }
}
