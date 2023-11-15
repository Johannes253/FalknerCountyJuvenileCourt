using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FalknerCountyJuvenileCourt.Pages.Crimes
{
    public class CrimeNamePageModel : PageModel
    {
        public SelectList OffenseNameSL { get; set; }
        public SelectList IntakeNameSL { get; set; }
        public SelectList FilingNameSL {get;set;}
        public SelectList SchoolNameSL {get;set;}
        public SelectList JuvenileNameSL {get;set;}

        public void PopulateOffensesDropDownList(CourtContext _context,
            object selectedOffense = null)
        {
            var offensesQuery = from d in _context.Offenses
                                   orderby d.Name // Sort by name.
                                   select d;

            OffenseNameSL = new SelectList(offensesQuery.AsNoTracking(),
                nameof(Offense.ID),
                nameof(Offense.Name),
                selectedOffense);
        }
        public void PopulateIntakeDropDownList(CourtContext _context,
            object selectedIntake = null)
        {
            var intakesQuery = from d in _context.IntakeDecisions
                                   orderby d.Name // Sort by name.
                                   select d;

            IntakeNameSL = new SelectList(intakesQuery.AsNoTracking(),
                nameof(IntakeDecision.ID),
                nameof(IntakeDecision.Name),
                selectedIntake);
        }
        public void PopulateFilingDropDownList(CourtContext _context,
            object selectedFiling = null)
        {
            var filingsQuery = from d in _context.FilingDecisions
                                   orderby d.Name // Sort by name.
                                   select d;

            FilingNameSL = new SelectList(filingsQuery.AsNoTracking(),
                nameof(FilingDecision.ID),
                nameof(FilingDecision.Name),
                selectedFiling);
        }
        public void PopulateSchoolDropDownList(CourtContext _context,
            object selectedSchool = null)
        {
            var schoolsQuery = from d in _context.Schools
                                   orderby d.Name // Sort by name.
                                   select d;

            SchoolNameSL = new SelectList(schoolsQuery.AsNoTracking(),
                nameof(School.ID),
                nameof(School.Name),
                selectedSchool);
        }
        public void PopulateJuvenilesDropDownList(CourtContext _context,
            object selectedJuvenile = null)
        {
            var juvenilesQuery = from d in _context.Juveniles
                                   orderby d.ID // Sort by name.
                                   select d;

            JuvenileNameSL = new SelectList(juvenilesQuery.AsNoTracking(),
                nameof(Juvenile.ID),
                nameof(Juvenile.ID),
                selectedJuvenile);
        }
    }
}