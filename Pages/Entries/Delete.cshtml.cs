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
    public class DeleteModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public DeleteModel(BeerComp.Models.BeerCompContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BeerEntry BeerEntry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BeerEntry = await _context.BeerEntry.FirstOrDefaultAsync(m => m.ID == id);

            if (BeerEntry == null)
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

            BeerEntry = await _context.BeerEntry.FindAsync(id);

            if (BeerEntry != null)
            {
                _context.BeerEntry.Remove(BeerEntry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
