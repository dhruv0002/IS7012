using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatAgarwadu.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid first name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid last name")]
        public string LastName { get; set; }

        [DisplayName("Target Salary")]
        [Range(50000, 1000000, ErrorMessage = "Enter valid salary")]
        public decimal TargetSalary { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Start Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("Company")]
        public Company CompanyAssoc { get; set; }

        [DisplayName("Job Title")]
        public JobTitle JobTitleAssoc { get; set; }

        [DisplayName("Company Associated")]
        public int? CompanyAssocId { get; set; }

        [DisplayName("Job Title Associated")]
        public int JobTitleAssocId { get; set; }

        [DisplayName("Industry")]
        public Industry IndustryAssoc { get; set; }

        [DisplayName("Industry Associated")]
        public int IndustryAssocId { get; set; }

        [Range(0, 100, ErrorMessage = "Enter valid experience")]
        public int Experience { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("LinkedIn Url")]
        [Required(ErrorMessage = "LinkedIn url is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid LinkedIn url")]
        [Url]
        public string LinkedInUrl { get; set; }

        [DisplayName("Phone No.")]
        [Required(ErrorMessage = "Phone no. is required")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Enter valid Phone no.")]
        [Phone]
        public string PhoneNo { get; set; }

    }
}
