using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeerComp.Models;

namespace BeerComp.Pages.Voters
{
    public class IndexModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public IndexModel(BeerComp.Models.BeerCompContext context)
        {
            _context = context;
        }

        public IList<Voter> Voter { get;set; }

        public async Task OnGetAsync()
        {
            Voter = await _context.Voter.ToListAsync();
        }
    }
}
