using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TestRazorWebApp.Models;

namespace TestRazorWebApp.Pages.CreateJD
{
    
    public class IndexModel : PageModel
    {
        JobDesc jobDesc;
        public IndexModel()
        {

        }

        public void OnGet()
        {
            jobDesc = new JobDesc();
        }
    }
}
