using Microsoft.AspNetCore.Mvc;

namespace TestWebApp.Controllers
{
    public class CreateJDController : Controller
    {
        private readonly ILogger<CreateJDController> _logger;
        public CreateJDController(ILogger<CreateJDController> logger) 
        {
            _logger = logger;
        }

        public IActionResult index()
        {
            return View();
        }
    }
}
