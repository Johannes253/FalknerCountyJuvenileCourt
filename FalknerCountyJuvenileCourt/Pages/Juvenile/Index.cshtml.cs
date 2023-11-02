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
    public class IndexModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public IndexModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        public IList<Juvenile> Juvenile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Juvenile != null)
            {
                Juvenile = await _context.Juvenile
                .Include(j => j.Race).ToListAsync();
            }
        }
    }
}
