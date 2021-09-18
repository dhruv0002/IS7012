using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatAgarwadu.Models
{
    public class Candidate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal TargetSalary { get; set; }
        public DateTime? StartDate { get; set; }
        public Company CompanyAssoc { get; set; }
        public JobTitle JobTitleAssoc { get; set; }
        public int? CompanyAssocId { get; set; }
        public int JobTitleAssocId { get; set; }
        public Industry IndustryAssoc { get; set; }
        public int IndustryAssocId { get; set; }
        public int Experience { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
