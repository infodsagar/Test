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
        public CreateAppController(ILogger<CreateAppController> logger) 
        {
            _logger = logger;
        }

        public IActionResult index()
        {
            createAppVM.sourceList = new List<SelectListItem>
            {
                new SelectListItem{ Text = "Linkedin", Value="Linkedin"},
                new SelectListItem{ Text = "Seek", Value="Seek"}
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
    }
}
