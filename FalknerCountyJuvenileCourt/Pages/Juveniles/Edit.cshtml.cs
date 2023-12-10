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
               .Include(j => j.Race)
               .Include(j => j.Gender)
               .Include(j => j.Risk)
               .Include(j => j.Crimes)
               .FirstOrDefaultAsync(m => m.ID == id);

            if (Juvenile == null)
            {
                return NotFound();
            }

            // Select current DepartmentID.
            PopulateRacesDropDownList(_context, Juvenile.RaceID);
            PopulateGendersDropDownList(_context, Juvenile.GenderID);
            PopulateRisksDropDownList(_context, Juvenile.RiskID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (id == null) {
               return NotFound();
            }

            var juvenileToUpdate = await _context.Juveniles.FindAsync(id);

            if (juvenileToUpdate == null) {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Juvenile>(
                  juvenileToUpdate, "Juvenile", 
                  j => j.FaulknerCountyIdentification,
                  j => j.Age, 
                  j => j.RaceID, 
                  j => j.GenderID,
                  j => j.RiskID,
                  j => j.Repeat)) 
               {
               await _context.SaveChangesAsync();
               Console.WriteLine($"Juvenile with ID {id} successfully updated.");
               return RedirectToPage("./Index");
            }

            Console.WriteLine($"Update failed for Juvenile with ID {id}. Model state errors:");
            foreach (var key in ModelState.Keys)
            {
                var modelStateEntry = ModelState[key];
                foreach (var error in modelStateEntry.Errors)
                {
                    Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                }
            }
            if (id == null) {
               return NotFound();
            }

            // Juvenile = await _context.Juveniles
            //    .Include(j => j.Race)
            //    .Include(j => j.Gender)
            //    .Include(j => j.Risk)
            //    .Include(j => j.Crimes)
            //    .FirstOrDefaultAsync(m => m.ID == id);

            // if (Juvenile == null) {
            //     return NotFound();
            // }

            // if (await TryUpdateModelAsync<Juvenile>(
            //       Juvenile, "juvenile", 
            //       j => j.Age, 
            //       j => j.RaceID, 
            //       j => j.GenderID,
            //       j => j.RiskID,
            //       j => j.Repeat)) 
            //    {
            //    await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            // }

            PopulateRacesDropDownList(_context, juvenileToUpdate.RaceID);
            PopulateGendersDropDownList(_context, juvenileToUpdate.GenderID);
            PopulateRisksDropDownList(_context, juvenileToUpdate.RiskID);
            return Page();
        }
    }
}
