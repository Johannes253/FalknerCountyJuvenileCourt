using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Crimes
{
    public class CreateModel : CrimeNamePageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public CreateModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet() {
            PopulateOffensesDropDownList(_context);
            PopulateIntakeDropDownList(_context);
            PopulateFilingDropDownList(_context);
            PopulateSchoolDropDownList(_context);
            PopulateJuvenilesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Crime Crime { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
      public async Task<IActionResult> OnPostAsync() {
         var emptyCrime = new Crime();

         if (await TryUpdateModelAsync<Crime>(
            emptyCrime,
            "crime",   // Prefix for form value.
            c => c.Offense, c => c.IntakeDecision, c => c.FilingDecision, c => c.School, c => c.Juvenile))
         {
            _context.Crimes.Add(emptyCrime);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
         }


         PopulateOffensesDropDownList(_context, emptyCrime.Offense);
         PopulateIntakeDropDownList(_context, emptyCrime.IntakeDecision);
         PopulateFilingDropDownList(_context, emptyCrime.FilingDecision);
         PopulateSchoolDropDownList(_context, emptyCrime.School);
         PopulateJuvenilesDropDownList(_context, emptyCrime.Juvenile);
         return Page();
      }
    }
}
