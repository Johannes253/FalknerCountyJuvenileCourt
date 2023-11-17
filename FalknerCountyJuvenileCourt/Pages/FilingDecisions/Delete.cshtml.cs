using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.FilingDecisions
{
    public class DeleteModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public DeleteModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FilingDecision FilingDecision { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FilingDecisions == null)
            {
                return NotFound();
            }

            var filingDecision = await _context.FilingDecisions.FirstOrDefaultAsync(m => m.ID == id);

            if (filingDecision == null)
            {
                return NotFound();
            }
            else 
            {
                FilingDecision = filingDecision;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FilingDecisions == null)
            {
                return NotFound();
            }
            var filingDecision = await _context.FilingDecisions.FindAsync(id);

            if (filingDecision != null)
            {
                FilingDecision = filingDecision;
                _context.FilingDecisions.Remove(FilingDecision);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
