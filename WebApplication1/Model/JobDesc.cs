using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestRazorWebApp.Models
{
    public class JobDesc
    {
        [Key]
        public int JobDescId { get; set; }

        [Required]
        public string JobDescription { get; set; }

        public int ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
