using System.ComponentModel.DataAnnotations;

namespace ADE_Web.Models.ViewModels
{
    public class CreateBlogViewModel
    {
        [Required]
        public string BlogTitle { get; set; } = string.Empty;
        public string BlogContent { get; set; } = string.Empty;
    }
}
