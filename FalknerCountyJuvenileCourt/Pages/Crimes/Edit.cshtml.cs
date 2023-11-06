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
    public class EditModel : PageModel
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
            if (id == null || _context.Crimes == null)
            {
                return NotFound();
            }

            var crime =  await _context.Crimes.FirstOrDefaultAsync(m => m.ID == id);
            if (crime == null)
            {
                return NotFound();
            }
            Crime = crime;
           ViewData["FilingDecisionID"] = new SelectList(_context.FilingDecisions, "ID", "ID");
           ViewData["IntakeDecisionID"] = new SelectList(_context.IntakeDecisions, "ID", "ID");
           ViewData["JuvenileID"] = new SelectList(_context.Juveniles, "ID", "ID");
           ViewData["CrimeTypeID"] = new SelectList(_context.CrimeTypes, "ID", "Type");
           ViewData["SchoolID"] = new SelectList(_context.Schools, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Crime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CrimeExists(Crime.ID))
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

        private bool CrimeExists(int id)
        {
          return (_context.Crimes?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
