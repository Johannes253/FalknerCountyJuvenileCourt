using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FalknerCountyJuvenileCourt.Data;
using FalknerCountyJuvenileCourt.Models;
using ClosedXML.Excel;

namespace FalknerCountyJuvenileCourt.Pages;

public class ExcelDownloadModel : PageModel {
    private readonly ILogger<IndexModel> _logger;
    private readonly CourtContext _context;
    public ExcelDownloadModel(ILogger<IndexModel> logger, CourtContext context) {
        _logger = logger;
        _context = context;
    }

    public FileResult OnGet() {

        var juveniles = _context.Juveniles
            .Include(j => j.Race)
            .Include(j => j.Gender)
            .Include(j => j.Risk)
            .ToList();
        
        var crimes = _context.Crimes
            .Include(c => c.Offense)
            .Include(c => c.FilingDecision)
            .Include(c => c.IntakeDecision)
            .Include(c => c.School)
            .ToList();

        using (var workbook = new XLWorkbook()) {
            IXLWorksheet juvenileworksheet =
            workbook.Worksheets.Add("Juveniles");
            juvenileworksheet.Cell(1, 1).Value = "Faulkner County Juvenile ID";
            juvenileworksheet.Cell(1, 2).Value = "Age";
            juvenileworksheet.Cell(1, 3).Value = "Race";
            juvenileworksheet.Cell(1, 4).Value = "Gender";
            juvenileworksheet.Cell(1, 5).Value = "Risk";
            juvenileworksheet.Cell(1, 6).Value = "Repeat Offender";

            IXLRange range = juvenileworksheet.Range(juvenileworksheet.Cell(1, 1).Address, juvenileworksheet.Cell(1, 6).Address);

            int index = 1;

            foreach (var juvenile in juveniles) {
                index++;

                juvenileworksheet.Cell(index, 1).Value = juvenile.FaulknerCountyIdentification;
                juvenileworksheet.Cell(index, 2).Value = juvenile.Age;
                juvenileworksheet.Cell(index, 3).Value = juvenile.Race?.ToString() ?? string.Empty;
                juvenileworksheet.Cell(index, 4).Value = juvenile.Gender?.ToString() ?? string.Empty;
                juvenileworksheet.Cell(index, 5).Value = juvenile.Risk?.ToString() ?? "Unknown";
                juvenileworksheet.Cell(index, 6).Value = juvenile.Repeat ? "Yes" : "No";


            }

        IXLWorksheet crimeWorksheet = workbook.Worksheets.Add("Crimes");
        crimeWorksheet.Cell(1, 1).Value = "Offense";
        crimeWorksheet.Cell(1, 2).Value = "Filing Decision";
        crimeWorksheet.Cell(1, 3).Value = "Intake Decision";
        crimeWorksheet.Cell(1, 4).Value = "School";
        crimeWorksheet.Cell(1, 5).Value = "Drug Offense";
        crimeWorksheet.Cell(1, 6).Value = "Drug Court";
        crimeWorksheet.Cell(1, 7).Value = "Date";
        crimeWorksheet.Cell(1, 8).Value = "Faulkner County Juvenile ID";

        index = 1;

        foreach (var crime in crimes)
        {
            index++;

            crimeWorksheet.Cell(index, 1).Value = crime.Offense?.ToString() ?? string.Empty;
            crimeWorksheet.Cell(index, 2).Value = crime.FilingDecision?.ToString() ?? string.Empty;
            crimeWorksheet.Cell(index, 3).Value = crime.IntakeDecision?.ToString() ?? string.Empty;
            crimeWorksheet.Cell(index, 4).Value = crime.School?.ToString() ?? string.Empty;
            crimeWorksheet.Cell(index, 5).Value = crime.DrugOffense ? "Yes" : "No";
            crimeWorksheet.Cell(index, 6).Value = crime.DrugCourt ? "Yes" : "No";
            crimeWorksheet.Cell(index, 7).Value = crime.Date?.ToString("yyyy-MM-dd") ?? string.Empty;

            var juvenileIdentification = _context.Juveniles
            .Where(j => j.ID == crime.JuvenileID)
            .Select(j => j.FaulknerCountyIdentification)
            .FirstOrDefault();
            crimeWorksheet.Cell(index, 8).Value = juvenileIdentification;
            
        }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                    var strDate = DateTime.Now.ToString("yyyy");
                    string filename = string.Format($"FaulknerCountyAnnualReport_{strDate}.xlsx");

                    return File(content, contentType, filename);
                }
        }
    }
}