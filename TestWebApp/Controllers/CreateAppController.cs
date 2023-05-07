using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestWebApp.Data;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class CreateAppController : Controller
    {
        private readonly ILogger<CreateAppController> _logger;
        public CreateAppVM createAppVM = new CreateAppVM();
        private JobTrackerDbContext _db;

        public CreateAppController(ILogger<CreateAppController> logger, JobTrackerDbContext db) 
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult index()
        {
            createAppVM.sourceList = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Linkedin", Value=$"{SourceEnum.Linkedin}"},
                new SelectListItem{ Text = "Seek", Value=$"{SourceEnum.Seek}"}
            };


            createAppVM.statusList = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Applied", Value="Applied"},
                new SelectListItem{ Text = "Rejected", Value="Rejected"},
                new SelectListItem{ Text = "Phone_Screen", Value="Phone Screen"},
                new SelectListItem{ Text = "Interview", Value="Interview"},
                new SelectListItem{ Text = "Job_Offer", Value="Job Offer"},
            };
            
            return View(createAppVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult index(CreateAppVM obj)
        {
            _db.Applications.Add(obj.application);
            _db.SaveChanges();
            ApplicationsVM applicationsVM = new ApplicationsVM { applicationList = _db.Applications };
            int Id = applicationsVM.applicationList.OrderByDescending(i => i.Id).First().Id;
            return RedirectToAction("Index","CreateJD", new {Id});
        }
    }
}
