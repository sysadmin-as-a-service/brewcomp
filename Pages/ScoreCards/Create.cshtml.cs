using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BeerComp.Models;

namespace BeerComp.Pages.ScoreCards
{
    public class CreateModel : PageModel
    {
        private readonly BeerComp.Models.BeerCompContext _context;

        [BindProperty]
        public List<SelectListItem> BeerEntries {get; set;}

        public CreateModel(BeerComp.Models.BeerCompContext context)
        {
            _context = context;

            // populate our list of available beer entries for the select dropdown
            BeerEntries = context.BeerEntry.Select(a =>
                                                    new SelectListItem{
                                                        Value = a.ID.ToString(),
                                                        Text = a.EntryName
                                                    }).ToList();
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ScoreCard ScoreCard { get; set; }

        [BindProperty]
        public Voter Voter {get; set;}

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // try find an existing owner with that email address
            var existingVoter = _context.Voter
                                    .Where(v => v.Email == Voter.Email)
                                    .FirstOrDefault();

            if(null == existingVoter){
                // couldn't find an existing Owner with that email,
                //   so let's create a new one
                _context.Voter.Add(Voter);
                _context.SaveChanges();
                ScoreCard.VoterID = Voter.ID;
            }else{
                ScoreCard.VoterID = existingVoter.ID;
            }

            //Calculate overall score
            ScoreCard.OverallScore = (
                ScoreCard.TasteScore +
                ScoreCard.LookScore +
                ScoreCard.OtherScore)/3;

            
            _context.ScoreCard.Add(ScoreCard);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
