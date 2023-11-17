using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Schools
{
    public class DeleteModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public DeleteModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        [BindProperty]
      public School School { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Schools == null)
            {
                return NotFound();
            }

            var school = await _context.Schools.FirstOrDefaultAsync(m => m.ID == id);

            if (school == null)
            {
                return NotFound();
            }
            else 
            {
                School = school;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Schools == null)
            {
                return NotFound();
            }
            var school = await _context.Schools.FindAsync(id);

            if (school != null)
            {
                School = school;
                _context.Schools.Remove(School);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
