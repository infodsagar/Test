using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class CreateJDController : Controller
    {
        private readonly ILogger<CreateJDController> _logger;
        private JobTrackerDbContext _db;
       

        public CreateJDController(ILogger<CreateJDController> logger, JobTrackerDbContext db) 
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult index(JobDesc obj)
        {
            if (Request.RouteValues["Id"] != null)
            {
                ApplicationsVM applicationsVM = new ApplicationsVM { applicationList = _db.Applications };
                obj.ApplicationId = applicationsVM.applicationList.OrderByDescending(i => i.Id).First().Id;
            }

            _db.JobDescs.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Applications");
        }
    }
}
