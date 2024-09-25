using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Volunteer
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Display(Name = "Preferred Task")]
        public string TaskAssigned { get; set; } = string.Empty;

        [Display(Name = "Availability (e.g., Weekdays, Weekends)")]
        public string Availability { get; set; } = string.Empty;

        [Display(Name = "Experience Level")]
        public string ExperienceLevel { get; set; } = string.Empty;

        [Display(Name = "Region of Service")]
        public string RegionOfService { get; set; } = string.Empty;
    }
}
