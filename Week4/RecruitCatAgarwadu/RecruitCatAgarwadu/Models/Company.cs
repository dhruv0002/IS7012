using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatAgarwadu.Models
{
    public class Company
    {
        public int Id { get; set; }

        [DisplayName("Company Name")]
        [Required(ErrorMessage = "Company name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Enter valid company name")]
        public string CompanyName { get; set; }

        [DisplayName("Position Name")]
        [Required(ErrorMessage = "Position name is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Enter valid position name")]
        public string PositionName { get; set; }

        [DisplayName("Minimum Salary")]
        [Range(50000, 1000000, ErrorMessage = "Enter valid salary")]
        public decimal MinSalary { get; set; }

        [DisplayName("Maximum Salary")]
        [Range(50000, 1000000, ErrorMessage = "Enter valid salary")]
        public decimal MaxSalary { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid location")]
        public string Location { get; set; }

        public List<Candidate> Candidates { get; set; }

        [DisplayName("Industry")]
        public Industry IndustryAssoc { get; set; }

        [DisplayName("Industry Associated")]
        public int IndustryAssocId { get; set; }

        [DisplayName("Work Permit Sponsership")]
        public bool WorkPermitSponsership { get; set; }

        [Range(5000000, int.MaxValue, ErrorMessage = "Enter valid revenue")]
        public decimal? Revenue { get; set; }

    }
}
