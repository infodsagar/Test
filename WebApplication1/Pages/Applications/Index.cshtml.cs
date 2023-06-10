using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
=======
>>>>>>> caaa3cac42f1ec332d2844f5e42ba22ea4b9538e
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
<<<<<<< HEAD

=======
>>>>>>> caaa3cac42f1ec332d2844f5e42ba22ea4b9538e
        }
    }
}
