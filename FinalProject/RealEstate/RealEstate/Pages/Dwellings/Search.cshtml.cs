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
    public class SearchModel : PageModel
    {
        private readonly RealEstate.Data.RealEstateContext _context;

        public SearchModel(RealEstate.Data.RealEstateContext context)
        {
            _context = context;
        }

        public IList<Dwelling> Dwelling { get;set; }
        public bool SearchCompleted { get; set; }
        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;

            if (!string.IsNullOrWhiteSpace(query))
            {
                Dwelling = await _context.Dwelling
                        .Where(d => d.DwellingName.StartsWith(query))
                        .Include(d => d.AgentAssoc)
                        .Include(d => d.CityAssoc)
                        .ToListAsync();

                if (Dwelling.Any())
                {
                    SearchCompleted = true;
                }
                else
                {
                    SearchCompleted = false;
                    Dwelling = new List<Dwelling>();
                }
            }
            else
            {
                SearchCompleted = false;
                Dwelling = new List<Dwelling>();
            }
        }
    }
}
