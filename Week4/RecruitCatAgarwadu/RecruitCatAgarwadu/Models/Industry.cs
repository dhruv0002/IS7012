using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecruitCatAgarwadu.Models
{
    public class Industry
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Enter valid name")]
        public string Name { get; set; }
        
        public List<Candidate> Candidates { get; set; }
        
        public List<Company> Companies { get; set; }

    }
}
