using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Crimes
{
    public class EditModel : CrimeNamePageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public EditModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Crime Crime { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Crime = await _context.Crimes
               .Include(c => c.Juvenile)
               .Include(c => c.Offense)
               .Include(c => c.IntakeDecision)
               .Include(c => c.FilingDecision)
               .Include(c => c.School)
               .FirstOrDefaultAsync(m => m.ID == id);

            if (Crime == null)
            {
                return NotFound();
            }


            PopulateOffensesDropDownList(_context, Crime.OffenseID);
            PopulateIntakeDropDownList(_context, Crime.IntakeDecisionID);
            PopulateFilingDropDownList(_context, Crime.FilingDecisionID);
            PopulateSchoolDropDownList(_context, Crime.SchoolID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crimeToUpdate = await _context.Crimes.FindAsync(id);

            if (crimeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Crime>(
                crimeToUpdate, "Crime",
                c => c.FilingDecisionID,
                c => c.IntakeDecisionID,
                c => c.Date,
                c => c.SchoolID,
                c => c.DrugOffense,
                c => c.DrugCourt,
                c => c.OffenseID))
            {
            crimeToUpdate.Juvenile.FaulknerCountyIdentification = Crime.Juvenile.FaulknerCountyIdentification;

            await _context.SaveChangesAsync();
            Console.WriteLine($"Crime with ID {id} successfully updated.");
            return RedirectToPage("./Index");
        }

        Console.WriteLine($"Update failed for Crime with ID {id}. Model state errors:");
        foreach (var key in ModelState.Keys)
        {
            var modelStateEntry = ModelState[key];
            foreach (var error in modelStateEntry.Errors)
            {
                Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
            }
        }

        PopulateOffensesDropDownList(_context, crimeToUpdate.OffenseID);
        PopulateIntakeDropDownList(_context, crimeToUpdate.IntakeDecisionID);
        PopulateFilingDropDownList(_context, crimeToUpdate.FilingDecisionID);
        PopulateSchoolDropDownList(_context, crimeToUpdate.SchoolID);
        return Page();
        }
    }
}
