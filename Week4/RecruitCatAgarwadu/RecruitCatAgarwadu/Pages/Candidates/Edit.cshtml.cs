using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RecruitCatAgarwadu.Data;
using RecruitCatAgarwadu.Models;

namespace RecruitCatAgarwadu.Pages.Candidates
{
    public class EditModel : PageModel
    {
        private readonly RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext _context;

        public EditModel(RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["CompanyAssocId"] = new SelectList(_context.Company, "Id", "CompanyName");
           ViewData["IndustryAssocId"] = new SelectList(_context.Industry, "Id", "Name");
           ViewData["JobTitleAssocId"] = new SelectList(_context.JobTitle, "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Candidate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidateExists(Candidate.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CandidateExists(int id)
        {
            return _context.Candidate.Any(e => e.Id == id);
        }
    }
}
