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

namespace FalknerCountyJuvenileCourt.Pages.IntakeDecisions
{
    public class EditModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public EditModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        [BindProperty]
        public IntakeDecision IntakeDecision { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IntakeDecisions == null)
            {
                return NotFound();
            }

            var intakeDecision =  await _context.IntakeDecisions.FirstOrDefaultAsync(m => m.ID == id);
            if (intakeDecision == null)
            {
                return NotFound();
            }
            IntakeDecision = intakeDecision;
         //   ViewData["FilingDecisionID"] = new SelectList(_context.FilingDecisions, "ID", "Name");
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

            _context.Attach(IntakeDecision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntakeExists(IntakeDecision.ID))
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

        private bool IntakeExists(int id)
        {
          return (_context.IntakeDecisions?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
