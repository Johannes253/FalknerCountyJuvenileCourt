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
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FalknerCountyJuvenileCourt.Pages.Crimes
{
    [Authorize]
    public class IndexModel : CrimeNamePageModel
    {
        private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

        private readonly IConfiguration Configuration;

        public IndexModel(CourtContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

         public string IDSort {get;set;}
         public string JuvenileSort {get;set;}
         public string OffenseSort {get;set;}
         public string IntakeSort {get;set;}
         public string FilingSort {get;set;}
         public string SchoolSort {get;set;}
         public string DOffenseSort {get;set;}
         public string DCourtSort {get;set;}
         public string DateSort {get;set;}
         public string CurrentSort {get;set;}
         public string DateFilter {get;set;}
         public string CurrentFilter {get;set;}

        public PaginatedList<Crime> Crimes { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchID, string dateFilter, string currentFilter, int? pageIndex) {
         CurrentSort = sortOrder;
         IDSort = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
         JuvenileSort = sortOrder == "Juvenile" ? "juvenile_desc" : "Juvenile";
         OffenseSort = sortOrder == "Offense" ? "offense_desc" : "Offense";
         IntakeSort = sortOrder == "Intake" ? "intake_desc" : "Intake";
         FilingSort = sortOrder == "Filing" ? "filing_desc" : "Filing";
         SchoolSort = sortOrder == "School" ? "school_desc" : "School";
         DOffenseSort = sortOrder == "DrugOffense" ? "drugOffense_desc" : "DrugOffense";
         DCourtSort = sortOrder == "DrugCourt" ? "drugCourt_desc" : "DrugCourt";
         DateSort = sortOrder == "Date" ? "date_desc" : "Date";

         if (dateFilter != null) {
            pageIndex = 1;
         } else {
            dateFilter = DateFilter;
         }

         if (searchID != null) {
            pageIndex = 1;
         }
         else {
            searchID = currentFilter;
         }

         // dateFilter = "2023";

         CurrentFilter = searchID;
         DateFilter = dateFilter;

         IQueryable<Crime> crimesIQ = from c in _context.Crimes select c;

         if (!String.IsNullOrEmpty(DateFilter)) {
            crimesIQ = crimesIQ.Where(c => c.Date.ToString().Contains(dateFilter));
         }
         if (!String.IsNullOrEmpty(searchID)) {
            crimesIQ = crimesIQ.Where(c => c.Juvenile.FaulknerCountyIdentification.Contains(searchID));
         }

         switch (sortOrder) {
            case "id_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.ID);
               break;
            case "Juvenile":
               crimesIQ = crimesIQ.OrderBy(s => s.Juvenile.FaulknerCountyIdentification);
               break;
            case "juvenile_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.Juvenile.FaulknerCountyIdentification);
               break;
            case "Offense":
               crimesIQ = crimesIQ.OrderBy(s => s.Offense);
               break;
            case "offense_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.Offense);
               break;
            case "Intake":
               crimesIQ = crimesIQ.OrderBy(s => s.IntakeDecision);
               break;
            case "intake_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.IntakeDecision);
               break;
            case "Filing":
               crimesIQ = crimesIQ.OrderBy(s => s.FilingDecision);
               break;
            case "filing_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.FilingDecision);
               break;
            case "School":
               crimesIQ = crimesIQ.OrderBy(s => s.School);
               break;
            case "school_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.School);
               break;
            case "DrugOffense":
               crimesIQ = crimesIQ.OrderBy(s => s.DrugOffense);
               break;
            case "drugOffense_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.DrugOffense);
               break;
            case "DrugCourt":
               crimesIQ = crimesIQ.OrderBy(s => s.DrugCourt);
               break;
            case "drugCourt_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.DrugCourt);
               break;
            case "Date":
               crimesIQ = crimesIQ.OrderBy(s => s.Date);
               break;
            case "date_desc":
               crimesIQ = crimesIQ.OrderByDescending(s => s.Date);
               break;
            default:
               crimesIQ = crimesIQ.OrderBy(s => s.ID);
               break;
         }

         var pageSize = Configuration.GetValue("PageSize", 4);
         Crimes = await PaginatedList<Crime>.CreateAsync
            (crimesIQ
               .Include(c => c.FilingDecision)
               .Include(c => c.IntakeDecision)
               .Include(c => c.Juvenile)
               .Include(c => c.Offense)
               .Include(c => c.School)
               .AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
