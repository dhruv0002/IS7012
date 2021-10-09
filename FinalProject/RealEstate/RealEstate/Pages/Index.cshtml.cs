using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstate.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly RealEstate.Data.RealEstateContext _context;

        public IndexModel(ILogger<IndexModel> logger, RealEstate.Data.RealEstateContext context)
        {
            _logger = logger;
            _context = context;
        }

        public int TotalAgents { get; set; }
        public int TotalDwellings { get; set; }
        public int TotalCities { get; set; }
        public int TotalSalesOffices { get; set; }

        public async Task OnGetAsync()
        {
            TotalAgents = await _context.Agent.CountAsync();
            TotalDwellings = await _context.Dwelling.CountAsync();
            TotalCities = await _context.City.CountAsync();
            TotalSalesOffices = await _context.SalesOffice.CountAsync();
        }
    }
}
