using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecruitCatAgarwadu.Data;
using RecruitCatAgarwadu.Models;

namespace RecruitCatAgarwadu.Pages.Companies
{
    public class DetailsModel : PageModel
    {
        private readonly RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext _context;

        public DetailsModel(RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext context)
        {
            _context = context;
        }

        public Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Company = await _context.Company
                .Include(c => c.Candidates)
                .Include(c => c.IndustryAssoc).FirstOrDefaultAsync(m => m.Id == id);

            if (Company == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
