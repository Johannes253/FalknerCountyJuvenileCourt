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

namespace FalknerCountyJuvenileCourt.Pages.FilingDecisions
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public IndexModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        public IList<FilingDecision> FilingDecisions { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.FilingDecisions != null)
            {
                FilingDecisions = await _context.FilingDecisions
                .ToListAsync();
            }
        }
    }
}
