namespace ADE_Web.Models.ViewModels
{
    public class UpdateAppsBuiltViewModel
    {
        public int AppId { get; set; }
        public string AppName { get; set; } = string.Empty;
        public string AppGitHubUrl { get; set; } = string.Empty;
        public string AppDescription { get; set; } = string.Empty;

        public List<UpdateAppImprovementViewModel> Improvements { get; set; } = new();
    }

    public class UpdateAppImprovementViewModel
    {
        public int Id { get; set; }
        public string Improvement { get; set; } = string.Empty;
    }
}
