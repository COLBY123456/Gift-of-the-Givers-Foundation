using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Donor Name")]
        public string DonorName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Resource Type")]
        public string ResourceType { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be a positive number.")]
        public int Quantity { get; set; } = 1;

        [DataType(DataType.Date)]
        [Display(Name = "Date Donated")]
        public DateTime DateDonated { get; set; } = DateTime.Now;

        [Display(Name = "Distribution Area")]
        public string DistributionArea { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public string Status { get; set; } = "Pending";  // Default value
    }
}
