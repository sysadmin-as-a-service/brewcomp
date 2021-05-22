using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BeerComp.Models;

namespace BeerComp.Pages.ScoreCards
{
    public class DeleteModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public DeleteModel(BeerComp.Models.BeerCompContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ScoreCard ScoreCard { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ScoreCard = await _context.ScoreCard.FirstOrDefaultAsync(m => m.ID == id);

            if (ScoreCard == null)
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

            ScoreCard = await _context.ScoreCard.FindAsync(id);

            if (ScoreCard != null)
            {
                _context.ScoreCard.Remove(ScoreCard);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
