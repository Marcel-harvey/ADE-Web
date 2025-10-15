namespace ADE_Web.Models.ViewModels
{
    public class UpdateBlogViewModel
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; } = string.Empty;
        public string BlogContent { get; set; } = string.Empty;
    }
}
