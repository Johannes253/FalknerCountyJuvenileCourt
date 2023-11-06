using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Crimes
{
    public class DetailsModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public DetailsModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

      public Crime Crime { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Crimes == null)
            {
                return NotFound();
            }

            var crime = await _context.Crimes.FirstOrDefaultAsync(m => m.ID == id);
            if (crime == null)
            {
                return NotFound();
            }
            else 
            {
                Crime = crime;
            }
            return Page();
        }
    }
}
