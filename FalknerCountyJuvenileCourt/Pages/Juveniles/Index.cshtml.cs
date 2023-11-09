using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FalknerCountyJuvenileCourt.Pages.Juveniles
{
   [Authorize]
    public class IndexModel : PageModel
    {
      private readonly FalknerCountyJuvenileCourt.Data.CourtContext _context;

      private readonly IConfiguration Configuration;

      public IndexModel(CourtContext context, IConfiguration configuration) {
         _context = context;
         Configuration = configuration;
      }


      public string IDSort {get;set;}
      public string AgeSort {get;set;}
      public string RaceSort {get;set;}
      public string GenderSort {get;set;}
      public string RiskSort {get;set;}
      public string RepeatSort {get;set;}
      public string CurrentSort {get;set;}
      public string CurrentFilter {get;set;}

      public PaginatedList<Juvenile> Juveniles {get;set;}

      public async Task OnGetAsync(string sortOrder, string searchID, string currentFilter, int? pageIndex) {
         CurrentSort = sortOrder;
         IDSort     = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
         AgeSort    = sortOrder == "Age" ? "age_desc" : "Age";
         RaceSort   = sortOrder == "Race" ? "race_desc" : "Race";
         GenderSort = sortOrder == "Gender" ? "gender_desc" : "Gender";
         RiskSort   = sortOrder == "Risk" ? "risk_desc" : "Risk";
         RepeatSort = sortOrder == "Repeat" ? "repeat_desc" : "Repeat";

         if (searchID != null) {
            pageIndex = 1;
         }
         else {
            searchID = currentFilter;
         }

         CurrentFilter = searchID;

         IQueryable<Juvenile> juvenilesIQ = from s in _context.Juveniles select s;

         if (!String.IsNullOrEmpty(searchID)) {
            juvenilesIQ = juvenilesIQ.Where(s => s.ID == int.Parse(searchID));
         }

         switch (sortOrder) {
            case "id_desc":
               juvenilesIQ = juvenilesIQ.OrderByDescending(s => s.ID);
               break;
            case "Age":
               juvenilesIQ = juvenilesIQ.OrderBy(s => s.Age);
               break;
            case "age_desc":
               juvenilesIQ = juvenilesIQ.OrderByDescending(s => s.Age);
               break;
            case "Race":
               juvenilesIQ = juvenilesIQ.OrderBy(s => s.Race);
               break;
            case "race_desc":
               juvenilesIQ = juvenilesIQ.OrderByDescending(s => s.Race);
               break;
            case "Gender":
               juvenilesIQ = juvenilesIQ.OrderBy(s => s.Gender);
               break;
            case "gender_desc":
               juvenilesIQ = juvenilesIQ.OrderByDescending(s => s.Gender);
               break;
            case "Risk":
               juvenilesIQ = juvenilesIQ.OrderBy(s => s.Risk);
               break;
            case "risk_desc":
               juvenilesIQ = juvenilesIQ.OrderByDescending(s => s.Risk);
               break;
            case "Repeat":
               juvenilesIQ = juvenilesIQ.OrderBy(s => s.Repeat);
               break;
            case "repeat_desc":
               juvenilesIQ = juvenilesIQ.OrderByDescending(s => s.Repeat);
               break;
            default:
               juvenilesIQ = juvenilesIQ.OrderBy(s => s.ID);
               break;
         }
         var pageSize = Configuration.GetValue("PageSize", 4);
         Juveniles = await PaginatedList<Juvenile>.CreateAsync(
            juvenilesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
