using System.ComponentModel.DataAnnotations;

namespace ADE_Web.Models
{
    public class TechStackModel
    {
        public int Id { get; set; }
        public string Language { get; set; } = string.Empty;
        [Range(0, 5, ErrorMessage = "Value must be between 0 and 5!")]
        public int Proficiency {  get; set; }
    }
}
