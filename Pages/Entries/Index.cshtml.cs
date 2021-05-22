using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeerComp.Models;


namespace BeerComp.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public IndexModel(BeerComp.Models.BeerCompContext context)
        {
            _context = context;
        }

        public IList<BeerEntry> BeerEntry { get;set; }

        public async Task OnGetAsync()
        {
        
            BeerEntry = await _context.BeerEntry
                            .Include("Owner")
                            .ToListAsync();
            
        }
    }
}
