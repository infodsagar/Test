using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApp.Models
{
    public class JobDesc
    {
        [Key]
        public int Id { get; set; }
        [Required]
        string JobDescription { get; set; }
        [ForeignKey("Application")]
        string ApplicationId { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
