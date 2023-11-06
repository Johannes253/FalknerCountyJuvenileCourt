using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FalknerCountyJuvenileCourt.Pages.Juveniles
{
    public class JuvenileNamePageModel : PageModel
    {
        public SelectList RaceNameSL { get; set; }
        public SelectList GenderNameSL { get; set; }
        public SelectList RiskNameSL {get;set;}

        public void PopulateRacesDropDownList(CourtContext _context,
            object selectedRace = null)
        {
            var racesQuery = from d in _context.Races
                                   orderby d.Name // Sort by name.
                                   select d;

            RaceNameSL = new SelectList(racesQuery.AsNoTracking(),
                nameof(Race.ID),
                nameof(Race.Name),
                selectedRace);
        }
        public void PopulateGendersDropDownList(CourtContext _context,
            object selectedGender = null)
        {
            var gendersQuery = from d in _context.Genders
                                   orderby d.Name // Sort by name.
                                   select d;

            GenderNameSL = new SelectList(gendersQuery.AsNoTracking(),
                nameof(Gender.ID),
                nameof(Gender.Name),
                selectedGender);
        }
        public void PopulateRisksDropDownList(CourtContext _context,
            object selectedRisk = null)
        {
            var risksQuery = from d in _context.Risks
                                   orderby d.Name // Sort by name.
                                   select d;

            RiskNameSL = new SelectList(risksQuery.AsNoTracking(),
                nameof(Risk.ID),
                nameof(Risk.Name),
                selectedRisk);
        }
    }
}