using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class SalesOffice
    {
        public int SalesOfficeId { get; set; }

        [DisplayName("Sales Office Name")]
        [Required(ErrorMessage = "Sales Office name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid Sales Office name")]
        public string SalesOfficeName { get; set; }

        public string Location { get; set; }

        public List<Agent> Agents { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Company URL")]
        [Required(ErrorMessage = "Company url is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid company url")]
        [Url]
        public string CompanyUrl { get; set; }

        [DisplayName("Phone No.")]
        [Required(ErrorMessage = "Phone no. is required")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Enter valid Phone no.")]
        [Phone]
        public string PhoneNo { get; set; }

    }
}
