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
    public class DeleteModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public DeleteModel(BeerComp.Models.BeerCompContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Voter Voter { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Voter = await _context.Voter.FirstOrDefaultAsync(m => m.ID == id);

            if (Voter == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Voter = await _context.Voter.FindAsync(id);

            if (Voter != null)
            {
                _context.Voter.Remove(Voter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
