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
    public class IndexModel : PageModel
    {
        private readonly RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext _context;

        public IndexModel(RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext context)
        {
            _context = context;
        }

        public IList<Candidate> Candidate { get;set; }

        public async Task OnGetAsync()
        {
            Candidate = await _context.Candidate
                .Include(c => c.CompanyAssoc)
                .Include(c => c.IndustryAssoc)
                .Include(c => c.JobTitleAssoc).ToListAsync();
        }
    }
}
