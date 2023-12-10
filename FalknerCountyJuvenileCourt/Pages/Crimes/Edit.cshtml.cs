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

            var offenseToUpdate = await _context.Offenses.FindAsync(id);
            var intakeToUpdate = await _context.IntakeDecisions.FindAsync(id);
            var filingToUpdate = await _context.FilingDecisions.FindAsync(id);
            var schoolToUpdate = await _context.Schools.FindAsync(id);

            if (offenseToUpdate == null || intakeToUpdate == null || filingToUpdate == null || schoolToUpdate == null) {
               return NotFound();
            }

            if (await TryUpdateModelAsync<Offense>(offenseToUpdate,"offense", c => c.ID, c => c.Name)) {
               await _context.SaveChangesAsync();
               return RedirectToPage("./Index");
            }
            if (await TryUpdateModelAsync<IntakeDecision>(intakeToUpdate,"intake decision?", c => c.ID, c => c.Name)) {
               await _context.SaveChangesAsync();
               return RedirectToPage("./Index");
            }
            if (await TryUpdateModelAsync<FilingDecision>(filingToUpdate,"filing", c => c.ID, c => c.Name)) {
               await _context.SaveChangesAsync();
               return RedirectToPage("./Index");
            }
            if (await TryUpdateModelAsync<School>(schoolToUpdate,"school", c => c.ID, c => c.Name)) {
               await _context.SaveChangesAsync();
               return RedirectToPage("./Index");
            }

            PopulateOffensesDropDownList(_context, offenseToUpdate);
            PopulateIntakeDropDownList(_context, intakeToUpdate);
            PopulateFilingDropDownList(_context, filingToUpdate);
            PopulateSchoolDropDownList(_context, schoolToUpdate);
            return Page();
        }
    }
}
