using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeerComp.Models;

namespace BeerComp.Pages.Entries
{
    public class CreateModel2 : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        public CreateModel2(BeerComp.Models.BeerCompContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BeerEntry BeerEntry { get; set; }

        [BindProperty]
        public Owner Owner {get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }          

            // try find an existing owner with that email address
            var existingOwner = _context.Owner
                                    .Where(o => o.Email == Owner.Email)
                                    .FirstOrDefault();

            if(null == existingOwner){
                // couldn't find an existing Owner with that email,
                //   so let's create a new one
                _context.Owner.Add(Owner);
                _context.SaveChanges();
                BeerEntry.OwnerID = Owner.ID;
            }else{
                BeerEntry.OwnerID = existingOwner.ID;
            }           

            // now, save the beer entry
            _context.BeerEntry.Add(BeerEntry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
