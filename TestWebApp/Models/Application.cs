using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Models
{
    public enum SorceEnum
    {

    }

    public enum StatusEnum
    {

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
        public SorceEnum Source { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
