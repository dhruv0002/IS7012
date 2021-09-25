using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RecruitCatAgarwadu.Data;
using RecruitCatAgarwadu.Models;

namespace RecruitCatAgarwadu.Pages.Companies
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
        ViewData["IndustryAssocId"] = new SelectList(_context.Industry, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Company Company { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Company.Add(Company);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
