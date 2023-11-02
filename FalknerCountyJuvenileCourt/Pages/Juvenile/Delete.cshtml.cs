using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Juvenile
{
    public class DeleteModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public DeleteModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Juvenile Juvenile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Juvenile == null)
            {
                return NotFound();
            }

            var juvenile = await _context.Juvenile.FirstOrDefaultAsync(m => m.JuvenileID == id);

            if (juvenile == null)
            {
                return NotFound();
            }
            else 
            {
                Juvenile = juvenile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Juvenile == null)
            {
                return NotFound();
            }
            var juvenile = await _context.Juvenile.FindAsync(id);

            if (juvenile != null)
            {
                Juvenile = juvenile;
                _context.Juvenile.Remove(Juvenile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
