namespace ADE_Web.Models
{
    public class AppImprovement
    {
        public int Id { get; set; }
        public string Improvement { get; set; } = string.Empty;
        // Foreign key to AppsBuilt's ID
        public int AppsBuiltId { get; set; }

        // Navigation Property
        public AppsBuilt? AppsBuilt { get; set; }
    }
}
