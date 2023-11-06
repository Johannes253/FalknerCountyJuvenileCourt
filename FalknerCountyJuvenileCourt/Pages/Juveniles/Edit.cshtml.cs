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

namespace FalknerCountyJuvenileCourt.Pages.Juveniles
{
    public class EditModel : JuvenileNamePageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public EditModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Juvenile Juvenile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Juvenile = await _context.Juveniles
               .Include(c => c.Race)
               .Include(c => c.Gender)
               .Include(c => c.Risk)
               .FirstOrDefaultAsync(m => m.ID == id);

            if (Juvenile == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateRacesDropDownList(_context, Juvenile.Race.ID);
            PopulateGendersDropDownList(_context, Juvenile.Gender.ID);
            PopulateRisksDropDownList(_context, Juvenile.Risk.ID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceToUpdate = await _context.Races.FindAsync(id);
            var genderToUpdate = await _context.Genders.FindAsync(id);
            var riskToUpdate = await _context.Risks.FindAsync(id);

            if (raceToUpdate == null || genderToUpdate == null || riskToUpdate == null) {
               return NotFound();
            }

            if (await TryUpdateModelAsync<Race>(raceToUpdate,"race", c => c.ID, c => c.Name)) {
               await _context.SaveChangesAsync();
               return RedirectToPage("./Index");
            }
            if (await TryUpdateModelAsync<Gender>(genderToUpdate,"gender", c => c.ID, c => c.Name)) {
               await _context.SaveChangesAsync();
               return RedirectToPage("./Index");
            }
            if (await TryUpdateModelAsync<Risk>(riskToUpdate,"risk", c => c.ID, c => c.Name)) {
               await _context.SaveChangesAsync();
               return RedirectToPage("./Index");
            }

            PopulateRacesDropDownList(_context, raceToUpdate.ID);
            PopulateGendersDropDownList(_context, genderToUpdate.ID);
            PopulateRisksDropDownList(_context, riskToUpdate.ID);
            return Page();
        }
    }
}
