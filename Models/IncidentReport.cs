using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class IncidentReport
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Incident Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Incident Description")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Date Reported")]
        public DateTime DateReported { get; set; } = DateTime.Now;

        [Display(Name = "Current Status")]
        public string Status { get; set; } = "Under Review";  // Default value

        [Display(Name = "Assigned Team")]
        public string AssignedTeam { get; set; } = string.Empty;

        [Display(Name = "Priority Level")]
        public string PriorityLevel { get; set; } = "Medium";  // Default value
    }
}
