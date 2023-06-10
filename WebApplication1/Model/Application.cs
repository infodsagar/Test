using System.ComponentModel.DataAnnotations;

namespace TestRazorWebApp.Models
{
    public enum SourceEnum
    {
        Linkedin,
        Seek,
    }

    public enum StatusEnum
    {
        Applied,
        Rejected,
        Phone_Screen,
        Interview,
        Job_Offer
    }

    public class Application
    {
        [Key]
<<<<<<< HEAD
        public int ApplicationId { get; set; }
=======
        public int Id { get; set; }
>>>>>>> caaa3cac42f1ec332d2844f5e42ba22ea4b9538e
        [Required]
        public string Company { get; set; }
        [Required]
        public string Position { get; set; }
        public string URL { get; set; }
        public SourceEnum Source { get; set; }
        public StatusEnum Status { get; set; }
        public virtual JobDesc JobDesc { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
