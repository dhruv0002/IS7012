using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Models
{
    public class Agent
    {
        public int AgentId { get; set; }

        [DisplayName("Agent Name")]
        [Required(ErrorMessage = "Agent name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid agent name")]
        public string AgentName { get; set; }

        [Range(50000, 1000000, ErrorMessage = "Enter valid salary")]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        public List<Dwelling> Dwellings { get; set; }

        [DisplayName("Sales Office")]
        public SalesOffice SalesOfficeAssoc { get; set; }

        [DisplayName("Sales Office Associated")]
        public int SalesOfficeAssocId { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Phone No.")]
        [Required(ErrorMessage = "Phone no. is required")]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "Enter valid Phone no.")]
        [Phone]
        public string PhoneNo { get; set; }

    }
}
