using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Pages.SalesOffices
{
    public class EditModel : PageModel
    {
        private readonly RealEstate.Data.RealEstateContext _context;

        public EditModel(RealEstate.Data.RealEstateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SalesOffice SalesOffice { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SalesOffice = await _context.SalesOffice.FirstOrDefaultAsync(m => m.SalesOfficeId == id);

            if (SalesOffice == null)
            {
                return NotFound();
            }
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

            //Email validation
            bool emailExist = await _context.SalesOffice.AnyAsync(x => x.Email.Equals(SalesOffice.Email, StringComparison.OrdinalIgnoreCase) && x.SalesOfficeId != SalesOffice.SalesOfficeId);

            if (emailExist)
            {
                ModelState.AddModelError("SalesOffice.Email", "Sales office with this Email already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SalesOffice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOfficeExists(SalesOffice.SalesOfficeId))
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

        private bool SalesOfficeExists(int id)
        {
            return _context.SalesOffice.Any(e => e.SalesOfficeId == id);
        }
    }
}
