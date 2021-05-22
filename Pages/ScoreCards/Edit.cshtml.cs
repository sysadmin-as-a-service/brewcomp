using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeerComp.Models;

namespace BeerComp.Pages.ScoreCards
{
    public class EditModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public EditModel(BeerComp.Models.BeerCompContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ScoreCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScoreCardExists(ScoreCard.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ScoreCardExists(int id)
        {
            return _context.ScoreCard.Any(e => e.ID == id);
        }
    }
}
