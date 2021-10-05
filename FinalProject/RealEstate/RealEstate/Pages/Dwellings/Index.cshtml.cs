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
    public class IndexModel : PageModel
    {
        private readonly RealEstate.Data.RealEstateContext _context;

        public IndexModel(RealEstate.Data.RealEstateContext context)
        {
            _context = context;
        }

        public IList<Dwelling> Dwelling { get;set; }

        public async Task OnGetAsync()
        {
            Dwelling = await _context.Dwelling
                .Include(d => d.AgentAssoc)
                .Include(d => d.CityAssoc).ToListAsync();
        }
    }
}
