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
                .Include(c => c.Race).FirstOrDefaultAsync(m => m.ID == id);

            if (Juvenile == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateRacesDropDownList(_context, Juvenile.Race.ID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var raceToUpdate = await _context.Races.FindAsync(id);

            if (raceToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Race>(
                 raceToUpdate,
                 "race",   // Prefix for form value.
                   c => c.ID, c => c.Name))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateRacesDropDownList(_context, raceToUpdate.ID);
            return Page();
        }
    }
}
