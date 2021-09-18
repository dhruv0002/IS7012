using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatAgarwadu.Models
{
    public class JobTitle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public List<Candidate> Candidates { get; set; }
        public string SkillsRequired { get; set; }
        public string Description { get; set; }

    }
}
