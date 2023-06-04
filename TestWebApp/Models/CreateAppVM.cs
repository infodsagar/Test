using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestWebApp.Models
{
    public class CreateAppVM
    {
        public Application application { get; set; }
        public SourceEnum source { get; set; }
        public List<SelectListItem> sourceList { get; set; }
        public StatusEnum status { get; set; }
        public List<SelectListItem> statusList { get; set; }
    }
}
