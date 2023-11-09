using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FalknerCountyJuvenileCourt.Pages.Crimes
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public IndexModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        public IList<Crime> Crimes { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Crimes != null)
            {
                Crimes = await _context.Crimes
                .Include(c => c.FilingDecision)
                .Include(c => c.IntakeDecision)
                .Include(c => c.Juvenile)
                .Include(c => c.Name)
                .Include(c => c.School).ToListAsync();
            }
        }
    }
}
