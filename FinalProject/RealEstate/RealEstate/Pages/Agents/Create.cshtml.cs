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

namespace RealEstate.Pages.Agents
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
            ViewData["SalesOfficeAssocId"] = new SelectList(_context.Set<SalesOffice>(), "SalesOfficeId", "SalesOfficeName");
            return Page();
        }

        [BindProperty]
        public Agent Agent { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["SalesOfficeAssocId"] = new SelectList(_context.Set<SalesOffice>(), "SalesOfficeId", "SalesOfficeName");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Date of birth validation
            int yearDiff = DateTime.Now.Year - Agent.DateOfBirth.Year;

            if(yearDiff < 18)
            {
                ModelState.AddModelError("Agent.DateOfBirth", "Agent must be 18 years or older");
            }

            //Email validation
            bool emailExist = await _context.Agent.AnyAsync(x => x.Email.Equals(Agent.Email, StringComparison.OrdinalIgnoreCase));

            if(emailExist)
            {
                ModelState.AddModelError("Agent.Email", "Agent with this Email already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Agent.Add(Agent);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
