using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;

namespace FalknerCountyJuvenileCourt.Pages.Races
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
        ViewData["ID"] = new SelectList(_context.Races, "ID");
        ViewData["Name"] = new SelectList(_context.Races, "Name");
            return Page();
        }

        [BindProperty]
        public Race Race { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Races == null || Race == null)
            {
                return Page();
            }

            _context.Races.Add(Race);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
