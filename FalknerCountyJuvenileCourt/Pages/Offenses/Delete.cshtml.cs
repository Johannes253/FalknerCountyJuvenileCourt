using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Offenses
{
    public class DeleteModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public DeleteModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Offense Offense { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Offenses == null)
            {
                return NotFound();
            }

            var offense = await _context.Offenses.FirstOrDefaultAsync(m => m.ID == id);

            if (offense == null)
            {
                return NotFound();
            }
            else 
            {
                Offense = offense;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Offenses == null)
            {
                return NotFound();
            }
            var offense = await _context.Offenses.FindAsync(id);

            if (offense != null)
            {
                Offense = offense;
                _context.Offenses.Remove(Offense);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
