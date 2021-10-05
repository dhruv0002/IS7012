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
    public class CreateModel : PageModel
    {
        private readonly RealEstate.Data.RealEstateContext _context;

        public CreateModel(RealEstate.Data.RealEstateContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SalesOffice SalesOffice { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Email validation
            bool emailExist = await _context.SalesOffice.AnyAsync(x => x.Email.Equals(SalesOffice.Email, StringComparison.OrdinalIgnoreCase));

            if (emailExist)
            {
                ModelState.AddModelError("SalesOffice.Email", "Sales office with this Email already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SalesOffice.Add(SalesOffice);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
