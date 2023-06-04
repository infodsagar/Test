using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestRazorWebApp.Data;
using TestRazorWebApp.Models;

namespace TestRazorWebApp.Pages.CreateApp
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackerDbContext _db;
        public CreateAppVM createAppVM = new CreateAppVM();
        public IndexModel(JobTrackerDbContext db)
        {
            _db = db;
        }

        public void OnGet()
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
        }
    }
}
