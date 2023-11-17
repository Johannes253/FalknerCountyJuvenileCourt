using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.IntakeDecisions
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
        ViewData["ID"] = new SelectList(_context.IntakeDecisions, "ID");
        ViewData["Name"] = new SelectList(_context.IntakeDecisions, "Name");
            return Page();
        }

        [BindProperty]
        public IntakeDecision IntakeDecision { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.IntakeDecisions == null || IntakeDecision == null)
            {
                return Page();
            }

            _context.IntakeDecisions.Add(IntakeDecision);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
