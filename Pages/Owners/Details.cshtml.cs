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
    public class DetailsModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public DetailsModel(BeerComp.Models.BeerCompContext context)
        {
            _context = context;
        }

        public Owner Owner { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Owner = await _context.Owner.FirstOrDefaultAsync(m => m.ID == id);

            if (Owner == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
