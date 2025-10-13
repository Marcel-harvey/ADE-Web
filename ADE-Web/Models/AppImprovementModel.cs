namespace ADE_Web.Models
{
    public class AppImprovementModel
    {
        public int Id { get; set; }
        public string Improvement { get; set; } = string.Empty;
        // Foreign key to AppsBuilt's ID
        public int AppsBuiltId { get; set; }

        // Navigation Property
        public AppsBuiltModel? AppsBuilt { get; set; }
    }
}
