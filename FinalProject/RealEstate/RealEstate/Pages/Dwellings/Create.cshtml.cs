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

namespace RealEstate.Pages.Dwellings
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
            ViewData["AgentAssocId"] = new SelectList(_context.Agent, "AgentId", "AgentName");
            ViewData["CityAssocId"] = new SelectList(_context.City, "CityId", "CityName");
            return Page();
        }

        [BindProperty]
        public Dwelling Dwelling { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ViewData["AgentAssocId"] = new SelectList(_context.Agent, "AgentId", "AgentName");
            ViewData["CityAssocId"] = new SelectList(_context.City, "CityId", "CityName");

            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Listing time validation
            int timeDiff = DateTime.Compare(DateTime.Now, Dwelling.ListingTime);

            if(timeDiff < 0)
            {
                ModelState.AddModelError("Dwelling.ListingTime", "Listing time must be earlier than current time");
            }

            //Cost validation
            if(Dwelling.IsForSale)
            {
                if(Dwelling.Cost <= 0)
                {
                    ModelState.AddModelError("Dwelling.Cost", "Cost is not valid as dwelling is for sale");
                }
                
            }

            //Dwelling validation
            bool dwellingExist = await _context.Dwelling.AnyAsync(x => x.DwellingName.Equals(Dwelling.DwellingName, StringComparison.OrdinalIgnoreCase) && x.CityAssocId == Dwelling.CityAssocId);

            if (dwellingExist)
            {
                ModelState.AddModelError("Dwelling.DwellingName", "Mentioned dwelling in selected city already exists");
                ModelState.AddModelError("Dwelling.CityAssocId", "Mentioned dwelling in selected city already exists");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dwelling.Add(Dwelling);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
