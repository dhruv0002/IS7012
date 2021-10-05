using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Pages.Agents
{
    public class SearchModel : PageModel
    {
        private readonly RealEstate.Data.RealEstateContext _context;

        public SearchModel(RealEstate.Data.RealEstateContext context)
        {
            _context = context;
        }

        public IList<Agent> Agent { get;set; }
        public bool SearchCompleted { get; set; }
        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;

            if(!string.IsNullOrWhiteSpace(query))
            {
                Agent = await _context.Agent
                        .Where(a => a.AgentName.StartsWith(query))
                        .Include(a => a.SalesOfficeAssoc)
                        .ToListAsync();

                if(Agent.Any())
                {
                    SearchCompleted = true;
                }
                else
                {
                    SearchCompleted = false;
                    Agent = new List<Agent>();
                }
            } 
            else
            {
                SearchCompleted = false;
                Agent = new List<Agent>();
            }
            
        }
    }
}
