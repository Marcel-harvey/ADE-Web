using System.ComponentModel.DataAnnotations;

namespace ADE_Web.Models
{
    public class BlogModel
    {
        public int Id {  get; set; }
        [Required]
        public string BlogTitle { get; set; } = string.Empty;
        [Required]
        public string BlogContent { get; set; } = string.Empty;
        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}
