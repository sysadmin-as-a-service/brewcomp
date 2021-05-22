using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeerComp.Models;

namespace BeerComp.Pages.Owners
{
    public class IndexModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public IndexModel(BeerComp.Models.BeerCompContext context)
        {
            _context = context;
        }

        public IList<Owner> Owner { get;set; }

        public async Task OnGetAsync()
        {
            Owner = await _context.Owner.ToListAsync();
        }
    }
}
