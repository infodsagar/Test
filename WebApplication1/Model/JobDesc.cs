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

<<<<<<< HEAD
        public int ApplicationId { get; set; }

        [ForeignKey("ApplicationId")]
        public Application Application { get; set; }
=======
        [ForeignKey("Application")]
        public int? ApplicationId { get; set; }

        public Application? Application { get; set; }
>>>>>>> caaa3cac42f1ec332d2844f5e42ba22ea4b9538e

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
