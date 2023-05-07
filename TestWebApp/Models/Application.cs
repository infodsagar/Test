using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
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
        public int Id { get; set; }
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
