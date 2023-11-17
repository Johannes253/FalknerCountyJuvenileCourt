using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Races
{
    public class DeleteModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public DeleteModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Race Race { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Races == null)
            {
                return NotFound();
            }

            var race = await _context.Races.FirstOrDefaultAsync(m => m.ID == id);

            if (race == null)
            {
                return NotFound();
            }
            else 
            {
                Race = race;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Races == null)
            {
                return NotFound();
            }
            var race = await _context.Races.FindAsync(id);

            if (race != null)
            {
                Race = race;
                _context.Races.Remove(Race);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
