using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitCatAgarwadu.Data;
using RecruitCatAgarwadu.Models;

namespace RecruitCatAgarwadu.Pages.Candidates
{
    public class CreateModel : PageModel
    {
        private readonly RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext _context;

        public CreateModel(RecruitCatAgarwadu.Data.RecruitCatAgarwaduContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CompanyAssocId"] = new SelectList(_context.Company, "Id", "CompanyName");
        ViewData["IndustryAssocId"] = new SelectList(_context.Industry, "Id", "Name");
        ViewData["JobTitleAssocId"] = new SelectList(_context.JobTitle, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public Candidate Candidate { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candidate.Add(Candidate);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
