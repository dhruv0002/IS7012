using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatAgarwadu.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string PositionName { get; set; }
        public string MinSalary { get; set; }
        public DateTime MaxSalary { get; set; }
        public DateTime? StartDate { get; set; }
        public string Location { get; set; }
        public List<Candidate> Candidates { get; set; }
        public Industry IndustryAssoc { get; set; }
        public int IndustryAssocId { get; set; }
        public bool WorkPermitSponsership { get; set; }
        public decimal? Revenue { get; set; }

    }
}
