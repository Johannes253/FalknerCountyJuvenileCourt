using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Juveniles
{
    public class DetailsModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public DetailsModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

      public Juvenile Juvenile { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Juveniles == null)
            {
                return NotFound();
            }

            var juvenile = await _context.Juveniles
               .Include(s => s.Crimes)
               .AsNoTracking()
               .FirstOrDefaultAsync(m => m.ID == id);

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
    }
}
