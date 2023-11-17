using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Juveniles
{
    public class CreateModel : JuvenileNamePageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public CreateModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet() {
            PopulateRacesDropDownList(_context);
            PopulateGendersDropDownList(_context);
            PopulateRisksDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Juvenile Juvenile { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
      public async Task<IActionResult> OnPostAsync() {
         var emptyJuvenile = new Juvenile();
         
         if (await TryUpdateModelAsync<Juvenile>(
            emptyJuvenile,
            "juvenile",   // Prefix for form value.
            s => s.Age, s => s.Race, s => s.Gender, s => s.Repeat, s => s.Risk))
         {
            _context.Juveniles.Add(emptyJuvenile);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
         }
         var validationErrors = ModelState.Values.Where(E => E.Errors.Count > 0)
            .SelectMany(E => E.Errors)
            .Select(E => E.ErrorMessage)
            .ToList(); 

         PopulateRacesDropDownList(_context, emptyJuvenile.Race);
         PopulateGendersDropDownList(_context, emptyJuvenile.Gender);
         PopulateRisksDropDownList(_context, emptyJuvenile.Risk);
         return Page();
      }
    }
}
