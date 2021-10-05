using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Pages.Dwellings
{
    public class DeleteModel : PageModel
    {
        private readonly RealEstate.Data.RealEstateContext _context;

        public DeleteModel(RealEstate.Data.RealEstateContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dwelling Dwelling { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dwelling = await _context.Dwelling
                .Include(d => d.AgentAssoc)
                .Include(d => d.CityAssoc).FirstOrDefaultAsync(m => m.DwellingId == id);

            if (Dwelling == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dwelling = await _context.Dwelling.FindAsync(id);

            if (Dwelling != null)
            {
                _context.Dwelling.Remove(Dwelling);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
