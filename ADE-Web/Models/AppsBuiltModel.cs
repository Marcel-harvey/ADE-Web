namespace ADE_Web.Models
{
    public class AppsBuiltModel
    {
        public int Id { get; set; }
        public string AppName { get; set; } = string.Empty;
        public string AppGitHubUrl {  get; set; } = string.Empty;
        public string AppDescription {  get; set; } = string.Empty;

        // Navigation property to AppImprovement - many to one relationship
        public ICollection<AppImprovementModel> appImprovements {  get; set; } = new List<AppImprovementModel>();
    }
}
