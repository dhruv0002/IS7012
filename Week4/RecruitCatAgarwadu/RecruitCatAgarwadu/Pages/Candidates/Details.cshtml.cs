using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatAgarwadu.Data;
using RecruitCatAgarwadu.Models;

namespace RecruitCatAgarwadu.Pages.Candidates
{
    public class DetailsModel : PageModel
    {
        private readonly RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext _context;

        public DetailsModel(RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext context)
        {
            _context = context;
        }

        public Candidate Candidate { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Candidate = await _context.Candidate
                .Include(c => c.CompanyAssoc)
                .Include(c => c.IndustryAssoc)
                .Include(c => c.JobTitleAssoc).FirstOrDefaultAsync(m => m.Id == id);

            if (Candidate == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
