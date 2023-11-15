using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.FilingDecisions
{
    public class CreateModel : PageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        public CreateModel(FalknerCountyJuvenileCourt.Data.CourtContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ID"] = new SelectList(_context.FilingDecisions, "ID");
        ViewData["Name"] = new SelectList(_context.FilingDecisions, "Name");
            return Page();
        }

        [BindProperty]
        public FilingDecision FilingDecision { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.FilingDecisions == null || FilingDecision == null)
            {
                return Page();
            }

            _context.FilingDecisions.Add(FilingDecision);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
