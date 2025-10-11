namespace ADE_Web.Models.ViewModels
{
    public class CreateAppsBuildViewModel
    {
        public string AppName { get; set; } = string.Empty;
        public string AppGitHubUrl { get; set; } = string.Empty;
        public string AppDescription { get; set; } = string.Empty;

        public List<CreateAppImprovementViewModel> Improvements { get; set; } = new();
    }

    public class CreateAppImprovementViewModel
    {
        public string Improvement { get; set; } = string.Empty;
    }
}
