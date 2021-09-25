using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RecruitCatAgarwadu.Models
{
    public class JobTitle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Enter valid title")]
        public string Title { get; set; }
        
        [DisplayName("Minimum Salary")]
        [Range(50000, 1000000, ErrorMessage = "Enter valid salary")]
        public decimal MinSalary { get; set; }

        [DisplayName("Maximum Salary")]
        [Range(50000, 1000000, ErrorMessage = "Enter valid salary")]
        public decimal MaxSalary { get; set; }
        
        public List<Candidate> Candidates { get; set; }

        [DisplayName("Skills Required")]
        [Required(ErrorMessage = "Skills required is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid skills required")]
        public string SkillsRequired { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Enter valid description")]
        public string Description { get; set; }

    }
}
