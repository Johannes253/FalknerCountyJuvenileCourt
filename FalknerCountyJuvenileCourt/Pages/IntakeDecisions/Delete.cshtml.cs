using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.IntakeDecisions
{
    public class DeleteModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public DeleteModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
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

            var intakeDecision = await _context.IntakeDecisions.FirstOrDefaultAsync(m => m.ID == id);

            if (intakeDecision == null)
            {
                return NotFound();
            }
            else 
            {
                IntakeDecision = intakeDecision;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.IntakeDecisions == null)
            {
                return NotFound();
            }
            var intakeDecision = await _context.IntakeDecisions.FindAsync(id);

            if (intakeDecision != null)
            {
                IntakeDecision = intakeDecision;
                _context.IntakeDecisions.Remove(IntakeDecision);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
