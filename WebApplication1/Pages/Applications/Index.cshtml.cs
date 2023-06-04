using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestRazorWebApp.Data;
using TestRazorWebApp.Models;

namespace TestRazorWebApp.Pages.Applications
{
    public class IndexModel : PageModel
    {
        private readonly JobTrackerDbContext _db;
        public ApplicationsVM applicationsVM = new ApplicationsVM();
        public IndexModel(JobTrackerDbContext db)
        {
            _db = db;
        }


        public void OnGet()
        {
            applicationsVM.applicationList = _db.Applications;
            applicationsVM.jobDescList = _db.JobDescs;
        }
    }
}
